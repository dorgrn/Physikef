using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Physikef.GameScenes.Pendulum
{
    public class QuestionTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_QuestionText;
        [SerializeField] private TextMeshProUGUI[] m_ChoicesLabels;
        private Exercise m_CurrentExercise;

        public Exercise CurrentExercise => m_CurrentExercise;

        async void Start()
        {
            await initExercise();
        }

        private async Task initExercise()
        {
            m_CurrentExercise = await getExerciseForStudentAsync();

            if (m_CurrentExercise == null)
            {
                throw new Exception("Didn't find exercise for scene");
            }

            m_QuestionText.text = m_CurrentExercise.Question;

            if (m_ChoicesLabels.Length != m_CurrentExercise.Answers.Count())
            {
                throw new Exception("Question choices and actual text labels differ in size!");
            }

            for (var i = 0; i < m_ChoicesLabels.Length; i++)
            {
                m_ChoicesLabels[i].text = m_CurrentExercise.Answers.ToList()[i];
            }
        }

        private async Task<Exercise> getExerciseForStudentAsync()
        {
            Exercise result;
            IEnumerable<Exercise> allExercises = (await ServicesManager.GetDataAccessLayer()
                .GetAllExercisesAsync()).ToList();
            string chosenExercise = PlayerPrefs.GetString("chosenExercise");

            Exercise chosenExerciseInstance =
                allExercises.FirstOrDefault(ex => ex.SceneName == SceneManager.GetActiveScene().name);

            result = chosenExerciseInstance != null &&
                     SceneManager.GetActiveScene().name == chosenExerciseInstance.SceneName
                ? chosenExerciseInstance
                : allExercises.FirstOrDefault(ex => ex.ExerciseName == chosenExercise);

            return result;
        }
    }
}