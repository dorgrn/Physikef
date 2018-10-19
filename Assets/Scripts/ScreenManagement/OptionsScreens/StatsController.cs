using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] private ScrollViewToggleFiller m_ScrollViewToggleFiller;
        private StudentInputTextSupplier m_StudentInputTextSupplier;
        private ExerciseInputTextSupplier m_ExerciseInputTextSupplier;

        private void Start()
        {
            m_StudentInputTextSupplier = gameObject.AddComponent<StudentInputTextSupplier>();
            m_ExerciseInputTextSupplier = gameObject.AddComponent<ExerciseInputTextSupplier>();
        }


        public async void StudentButton_OnClick()
        {
            await m_ScrollViewToggleFiller.InitToggleLayoutAsync(m_StudentInputTextSupplier);
        }

        public async void ExercisesButton_OnClick()
        {
            await m_ScrollViewToggleFiller.InitToggleLayoutAsync(m_ExerciseInputTextSupplier);
        }

        public static async Task<string> GetStudentStatsAnalysisAsync(string email)
        {
            User student = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(email);
            IEnumerable<StudentExerciseResult> exercisesAnswered =
                await ServicesManager.GetDataAccessLayer().GetStudentStatisticsAsync(email);
            ILookup<bool, StudentExerciseResult> resultsByCorrectness =
                exercisesAnswered.ToLookup(exe => exe.isCorrect);

            IEnumerable<StudentExerciseResult> correctExercises = resultsByCorrectness[true];
            IEnumerable<StudentExerciseResult> incorrectExercises = resultsByCorrectness[false];

            int correctExeAmount = (int) correctExercises?.Count();
            int incorrectExeAmount = (int) incorrectExercises?.Count();
            float sum = correctExeAmount + incorrectExeAmount;
            float correctPer = sum.Equals(0)
                ? 0
                : correctExeAmount / sum;

            return
                $"Name:{student.displayname}\nEmail:{student.email}\nId:{student.userid}\nCorrect answers:{correctExeAmount}/{sum}({correctPer:P2})\n";
        }

        public static async Task<string> GetExeStatsAnalysisAsync(string exerciseName)
        {
            IEnumerable<StudentExerciseResult> allExercisesAnswered =
                await ServicesManager.GetDataAccessLayer().GetAllStudentStatisticsAsync();

            IEnumerable<StudentExerciseResult> answeredExWithGivenQuestion =
                allExercisesAnswered.Where(ex => ex.ExerciseName == exerciseName);

            StudentExerciseResult[] exWithGivenQuestion = answeredExWithGivenQuestion as StudentExerciseResult[] ??
                                                          answeredExWithGivenQuestion.ToArray();

            float percentageRes = exWithGivenQuestion.Any()
                ? (float) exWithGivenQuestion.Count(ex => ex.isCorrect) / exWithGivenQuestion.Count()
                : 0;

            return
                $"Answered percentage:{percentageRes:P2}";
        }
    }
}