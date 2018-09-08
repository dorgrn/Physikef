using System.Collections;
using Exercises;
using GameScenes.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.Pendulum
{
    public class PendulumController : SceneController
    {
        [SerializeField] private GameObject m_QuestionUi;
        public Pendulum m_PendulumScript;
        private readonly int START_SCENE_DELAY_SECONDS = 3;



        protected override IEnumerator StartScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_QuestionUi.SetActive(false);
            m_PendulumScript.enabled = true;
        }

//        private bool calculateAnswer(string answer)
//        {
//            Debug.Log("Submitting answer: " + answer);
//            float answerFloat = float.Parse(answer);
//            List<float> choicesFloat = m_Exercise.Answers.Select(choice => float.Parse(choice)).ToList();
//
//            float actual = MathEquations.FindClosestToAnswer(choicesFloat, answerFloat);
//
//            return answerFloat.Equals(actual);
//        }
    }
}