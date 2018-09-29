using System.Collections;
using Physikef.Controller;
using UnityEngine;

namespace Physikef.GameScenes.Pendulum
{
    public class PendulumController : SceneController
    {
        [SerializeField] private GameObject m_QuestionUi;
        [SerializeField] private GameObject m_Pendulum;
        public Pendulum m_PendulumScript;
        private readonly int START_SCENE_DELAY_SECONDS = 1;
        private DirectionPointer.DirectionPointer m_DirectionPointer;

        private void Start()
        {
            m_DirectionPointer = FindObjectOfType<DirectionPointer.DirectionPointer>();
            m_DirectionPointer.SetTarget(m_QuestionUi);
        }

        protected override IEnumerator StartScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_QuestionUi.SetActive(false);
            m_PendulumScript.enabled = true;
            m_DirectionPointer.SetTarget(m_Pendulum);
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