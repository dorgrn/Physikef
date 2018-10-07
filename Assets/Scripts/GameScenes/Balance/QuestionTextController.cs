using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Physikef.GameScenes.Balance
{
    public class QuestionTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_QuestionText;
        [SerializeField] private TextMeshProUGUI[] m_ChoicesLabels;
        public Exercise sceneExercise;

        void Start()
        {
            initExercises(SceneManager.GetActiveScene().name);
        }

        private async void initExercises(string sceneName)
        {
            sceneExercise =
                //ATTENTION!! if you modify this line so make sure to also modify it in BalanceControllet.cs
                (await ServicesManager.GetDataAccessLayer().GetExercisesAsync(sceneName)).FirstOrDefault();

            if (sceneExercise == null)
            {
                throw new Exception("Didn't find exercise for scene");
            }

            m_QuestionText.text = sceneExercise.Question;

            if (m_ChoicesLabels.Length != sceneExercise.Answers.Count())
            {
                throw new Exception("Question choices and actual text labels differ in size!");
            }

            for (var i = 0; i < m_ChoicesLabels.Length; i++)
            {
                m_ChoicesLabels[i].text = sceneExercise.Answers.ToList()[i];
            }
        }
    }
}
