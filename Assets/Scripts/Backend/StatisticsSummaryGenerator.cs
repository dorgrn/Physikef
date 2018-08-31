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

        return string.Format("correct answers: {0} / {1}", correctAnswersCount, studentStatistics.Count());
    }
}