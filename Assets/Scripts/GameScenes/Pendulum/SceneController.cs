using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        private Exercise m_exercise;
        private SceneAttributes m_sceneAttributes = new SceneAttributes();
        public Pendulum m_pendulumScript;
        private readonly float TOLERANCE = 1.6f;
        private readonly int START_SCENE_DELAY_SECONDS = 3;

        private void Awake()
        {
            m_exercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
        }

        public void SubmitAnswer(string answer)
        {
            bool correctAnswer = m_applicationManager.isHardCodedAnswers
                ? m_exercise.Answer.Equals(answer)
                : calculateAnswer(answer);

            if (correctAnswer)
            {
                // GOOD
                Debug.Log("Correct!");
            }
            else
            {
                // BASD
                Debug.Log("BAD!");
            }

            StartCoroutine(startScene());
        }

        IEnumerator startScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_pendulumScript.enabled = true;
        }

        private bool calculateAnswer(string answer)
        {
            Debug.Log("submmting answer: " + answer);
            float answerFloat = float.Parse(answer);
            List<float> choicesFloat = m_exercise.Choices.Select(choice => float.Parse(choice)).ToList();

            float actual = MathEquations.FindClosestToAnswer(choicesFloat, answerFloat);

            return answerFloat.Equals(actual);
        }

        public bool isSuspended()
        {
            return m_pendulumScript.enabled;
        }
    }
}