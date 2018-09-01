using System.Collections.Generic;
using System.Linq;

public class StatisticsSummaryGenerator
{
    public string GenerateStatisticsCorrectAnswersSummary(IEnumerable<StudentExerciseResult> studentStatistics)
    {
        int correctAnswersCount = 0;

        foreach (var result in studentStatistics)
        {
            if (result.isCorrect)
            {
                correctAnswersCount++;
            }
        }

        return $"correct answers: {correctAnswersCount} / {studentStatistics.Count()}";
    }
}