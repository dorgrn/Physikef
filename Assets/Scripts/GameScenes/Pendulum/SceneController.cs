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
        [Inject] private ApplicationManager m_applicationManager;
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private GameObject m_QuestionUi;
        [SerializeField] private FeedbackTextController m_FeedbackTextController;
        private Exercise m_Exercise;
        public Pendulum pendulumScript;
        private readonly float TOLERANCE = 1.6f;
        private readonly int START_SCENE_DELAY_SECONDS = 3;

        private void Awake()
        {
            // TODO: temp implementation, assuming only one exercise for scene
            m_Exercise =
                m_ExercisePublisher.GetExercisesForScene(SceneManager.GetActiveScene().name)[0];
            mockCreateSceneAttributes();
        }

        public void SubmitAnswer(string answer)
        {
            bool correctAnswer = m_applicationManager.IsHardCodedAnswers
                ? m_Exercise.Answer.Equals(answer)
                : calculateAnswer(answer);

            Debug.Log("Submitting answer:" + answer);

            if (correctAnswer)
            {
                Debug.Log("Correct!");
                StartCoroutine(m_FeedbackTextController.ShowCorrect());
            }
            else
            {
                Debug.Log("BAD!");
                StartCoroutine(m_FeedbackTextController.ShowWrong());
            }

            StartCoroutine(startScene());
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
            List<float> choicesFloat = m_Exercise.Choices.Select(choice => float.Parse(choice)).ToList();

            float actual = MathEquations.FindClosestToAnswer(choicesFloat, answerFloat);

            return answerFloat.Equals(actual);
        }

        public bool isSuspended()
        {
            return pendulumScript.enabled;
        }

        private void mockCreateSceneAttributes()
        {
//            SceneAttributes.Gravity.Value = 9.8f;
//            SceneAttributes.RopeLength.Value = 150f;
        }
    }
}