using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TeachersOptionsController : MonoBehaviour
{
    [Inject] private ApplicationManager m_ApplicationManager;
    [SerializeField] private Text m_UsernameLabel;
    [SerializeField] private Text m_SchoolNameLabel;

    void Start()
    {
        InitLabels();
    }

    private void InitLabels()
    {
//        m_UsernameLabel.text = m_ApplicationManager.CurrentUser.displayname;
    }

    public static async Task<string> GetStudentStatsAnalysisAsync(string userId)
    {
        var exercisesAnswered = await ServicesManager.GetDataAccessLayer().GetStudentStatisticsAsync(userId);
        User student = await ServicesManager.GetDataAccessLayer().GetUserByIdAsync(userId);

        StudentExerciseResult[] exerciseResults =
            exercisesAnswered as StudentExerciseResult[] ?? exercisesAnswered.ToArray();
        var resultsByCorrectness = exerciseResults.GroupBy(exe => exe.isCorrect).ToArray();

        var correctExe = resultsByCorrectness.FirstOrDefault();
        var incorrectExe = resultsByCorrectness.SecondOrDefault();

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
        var exercisesAnswered = await ServicesManager.GetDataAccessLayer().GetAllStudentStatisticsAsync();

        var studentExerciseResults = exercisesAnswered as StudentExerciseResult[] ?? exercisesAnswered.ToArray();
        var correctExerciseWithQuestion =
            studentExerciseResults.Select(exe => exe.Question == question && exe.isCorrect);

        return
            $"Answered percentage:{correctExerciseWithQuestion: P2}";
    }
}