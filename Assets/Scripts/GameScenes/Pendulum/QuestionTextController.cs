using System;
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

        async void Start()
        {
            await initExercises();
        }

        private async Task initExercises()
        {
            Exercise exercise = await GetExerciseForStudentAsync();

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

        public static async Task<Exercise> GetExerciseForStudentAsync()
        {
            Exercise result;
            var exercisesForScene = await ServicesManager.GetDataAccessLayer()
                .GetExercisesAsync(SceneManager.GetActiveScene().name);

            // check for homework name for player (if exists)
            // TODO: when available field swiitch
//            if (PlayerPrefs.HasKey("chosenHomework"))
//            {
//                HomeWork hw = await ServicesManager.GetDataAccessLayer()
//                    .GetHomeworkByNameAsync(PlayerPrefs.GetString("chosenHomework"));
//
//                result = exercisesForScene.FirstOrDefault(exe => exe.ExerciseName == hw.ExerciseName);
//            }
//            else
//            {
                result = exercisesForScene.FirstOrDefault();
//            }

            return result;
        }
    }
}