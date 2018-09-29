using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Physikef.GameScenes.Pendulum
{
    public class QuestionTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_QuestionText;
        [SerializeField] private TextMeshProUGUI[] m_ChoicesLabels;

        void Start()
        {
            initExercises(SceneManager.GetActiveScene().name);
        }

        private async void initExercises(string sceneName)
        {
            Exercise exercise =
                (await ServicesManager.GetDataAccessLayer().GetExercisesAsync("Pendulum")).FirstOrDefault();

            if (exercise == null)
            {
                throw new Exception("Didn't find exercise for scene");
            }

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