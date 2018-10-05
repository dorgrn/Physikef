using Physikef.ScreenManagement.TeachersOptionsScreen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class StatsController : MonoBehaviour
    {
        [SerializeField] private ScrollViewToggleFiller m_ScrollViewToggleFiller;
        private StudentInputTextSupplier m_StudentInputTextSupplier = new StudentInputTextSupplier();
        private ExerciseInputTextSupplier m_ExerciseInputTextSupplier = new ExerciseInputTextSupplier();

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
            var exercisesAnswered = await ServicesManager.GetDataAccessLayer().GetStudentStatisticsAsync(email);
            User student = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(email);

            StudentExerciseResult[] exerciseResults =
                exercisesAnswered as StudentExerciseResult[] ?? exercisesAnswered.ToArray();
            var resultsByCorrectness = exerciseResults.GroupBy(exe => exe.isCorrect).ToArray();

            var correctExe = resultsByCorrectness[0];
            var incorrectExe = resultsByCorrectness[1];

            int correctExeAmount = correctExe?.Count() ?? 0;
            int incorrectExeAmount = incorrectExe?.Count() ?? 0;
            float sum = correctExeAmount + incorrectExeAmount;
            float correctPer = sum.Equals(0)
                ? 0
                : correctExeAmount / sum;

            return
                $"Name:{student.displayname}\nEmail:{student.email}\nId:{student.userid}\nCorrect answers:{correctExeAmount}/{sum}({correctPer:P2})\n";
        }

        public static async Task<string> GetExeStatsAnalysisAsync(string question)
        {
            IEnumerable<StudentExerciseResult> allExercisesAnswered =
                await ServicesManager.GetDataAccessLayer().GetAllStudentStatisticsAsync();

            IEnumerable<StudentExerciseResult> answeredExWithGivenQuestion =
                allExercisesAnswered.Where(ex => ex.Question == question);

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