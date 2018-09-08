using System;
using System.Linq;
using Exercises;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Controllers
{
    public class QuestionTextController : MonoBehaviour
    {
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private TextMeshProUGUI m_QuestionText;
        [SerializeField] private Text[] m_ChoicesLabels;

        void Start()
        {
            initExercises(SceneManager.GetActiveScene().name);
        }

        private async void initExercises(string sceneName)
        {
            Exercise exercise = await m_ExercisePublisher.GetExerciseForScene(sceneName);

            m_QuestionText.text = exercise.Question;

            if (m_ChoicesLabels.Length != exercise.Answers.Count())
            {
                throw new Exception("Question choices and actual text labels differ in size!");
            }

            for (var i = 0; i < m_ChoicesLabels.Length; i++)
            {
                m_ChoicesLabels[i].text = exercise.Answers.ToList()[i];
            }
        }
    }
}