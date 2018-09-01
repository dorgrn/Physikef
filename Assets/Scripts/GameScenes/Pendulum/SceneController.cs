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
        [Inject] private IExercisePublisher m_exercisePublisher;
        [SerializeField] private GameObject m_questionUI;
        [SerializeField] private FeedbackTextController m_feedbackTextController;
        private Exercise m_exercise;
        private readonly SceneAttributes m_sceneAttributes = new SceneAttributes();
        public Pendulum m_pendulumScript;
        private readonly float TOLERANCE = 1.6f;
        private readonly int START_SCENE_DELAY_SECONDS = 3;


        public SceneAttributes SceneAttributes
        {
            get { return m_sceneAttributes; }
        }

        private void Awake()
        {
            m_exercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            mockCreateSceneAttributes();
        }

        public void SubmitAnswer(string answer)
        {
            bool correctAnswer = m_applicationManager.isHardCodedAnswers
                ? m_exercise.Answers.ToList()[m_exercise.CorrectAnswerIndex].Equals(answer)
                : calculateAnswer(answer);

            Debug.Log("Submitting answer:" + answer);

            if (correctAnswer)
            {
                // GOOD
                Debug.Log("Correct!");
                StartCoroutine(m_feedbackTextController.ShowCorrect());
            }
            else
            {
                // BASD
                Debug.Log("BAD!");
                StartCoroutine(m_feedbackTextController.ShowWrong());
            }

            StartCoroutine(startScene());
        }

        IEnumerator startScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_questionUI.SetActive(false);
            m_pendulumScript.enabled = true;
        }

        private bool calculateAnswer(string answer)
        {
            Debug.Log("Submitting answer: " + answer);
            float answerFloat = float.Parse(answer);
            List<float> choicesFloat = m_exercise.Answers.Select(choice => float.Parse(choice)).ToList();

            float actual = MathEquations.FindClosestToAnswer(choicesFloat, answerFloat);

            return answerFloat.Equals(actual);
        }

        public bool isSuspended()
        {
            return m_pendulumScript.enabled;
        }

        private void mockCreateSceneAttributes()
        {
            SceneAttributes.Gravity.Value = 9.8f;
            SceneAttributes.RopeLength.Value = 150f;
        }
    }
}