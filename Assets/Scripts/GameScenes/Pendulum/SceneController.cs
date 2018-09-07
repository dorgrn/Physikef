using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using Exercises;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.Pendulum
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager m_ApplicationManager;
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private GameObject m_QuestionUi;
        [SerializeField] private FeedbackTextController m_FeedbackTextController;
        private Exercise m_Exercise;
        private SceneAttributes m_SceneAttributes { get; set; }
        public Pendulum pendulumScript;
        private readonly float TOLERANCE = 1.6f;
        private readonly int START_SCENE_DELAY_SECONDS = 3;


        private void Awake()
        {
            m_SceneAttributes = new SceneAttributes();
            mockCreateSceneAttributes();
        }

        public async void SubmitAnswer(string answer)
        {
            m_Exercise = m_Exercise ??
                         await m_ExercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            bool correctAnswer = m_ApplicationManager.IsHardCodedAnswers
                ? m_Exercise.Answers.ToList()[m_Exercise.CorrectAnswerIndex].Equals(answer)
                : calculateAnswer(answer);

            Debug.Log("Submitting answer:" + answer);

            StartCoroutine(
                correctAnswer ? m_FeedbackTextController.ShowCorrect() : m_FeedbackTextController.ShowWrong());

            StartCoroutine(startScene());
        }

        private async void SendUserAnswer(string answer, bool isCorrect)
        {
            string userid = m_ApplicationManager.CurrentUser.userid;
            StudentExerciseResult studentExerciseResult = new StudentExerciseResult()
            {
                AnsweringStudentId = userid,
                isCorrect = isCorrect,
                Question = m_Exercise.Question,
                StudentAnswer = answer
            };
            await ServicesManager.GetDataAccessLayer().AddStudentExerciseResultAsync(studentExerciseResult);
        }

        IEnumerator startScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_QuestionUi.SetActive(false);
            pendulumScript.enabled = true;
        }

        private bool calculateAnswer(string answer)
        {
            Debug.Log("Submitting answer: " + answer);
            float answerFloat = float.Parse(answer);
            List<float> choicesFloat = m_Exercise.Answers.Select(choice => float.Parse(choice)).ToList();

            float actual = MathEquations.FindClosestToAnswer(choicesFloat, answerFloat);

            return answerFloat.Equals(actual);
        }

        public bool isSuspended()
        {
            return pendulumScript.enabled;
        }

        private void mockCreateSceneAttributes()
        {
            m_SceneAttributes.Gravity.Value = 9.8f;
            m_SceneAttributes.RopeLength.Value = 150f;
        }
    }
}