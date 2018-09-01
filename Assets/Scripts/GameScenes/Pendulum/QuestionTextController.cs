using System;
using System.Linq;
using Exercises;
using Questions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace GameScenes.Pendulum
{
    public class QuestionTextController : MonoBehaviour
    {
        [Inject] private IExercisePublisher m_exercisePublisher;
        [SerializeField] private TextMeshProUGUI m_questionText;
        [SerializeField] private Text[] m_choicesLabels;

        void Start()
        {
            Exercise exercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            initExercises(exercise);
        }

        private void initExercises(Exercise exercise)
        {
            m_questionText.text = exercise.Question;

            if (m_choicesLabels.Length != exercise.Answers.Count())
            {
                throw new Exception("Question choices and actual text labels differ in size!");
            }

            for (var i = 0; i < m_choicesLabels.Length; i++)
            {
                m_choicesLabels[i].text = exercise.Answers.ToList()[i];
            }
        }
    }
}