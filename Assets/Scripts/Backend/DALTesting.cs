using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DALTesting : MonoBehaviour
{
    public Text text;

    public async void TestDal()
    {
        await HomeworkDALTest();
        await ExerciseDALTest();
        await StudentExerciseResultDALTest();
    }


    public async Task HomeworkDALTest()
    {
        var hw = new HomeWork()
        {
            CreatorName = "Olga",
            Name = "Test" + DateTime.Now,
            SceneName = "Pendullum",
            Students = new List<string>() {"1111", "2222"},
        };

        await ServicesManager.GetDataAccessLayer().AddHomeworkAsync(hw);

        var getHw = await ServicesManager.GetDataAccessLayer().GetHomeworkByUserEmailAsync("1111");

        if (getHw.Any(current => current.Name == hw.Name))
        {
            Debug.Log("Homework dal passed test");
        }
        else
        {
            Debug.LogError("Homework Dal failed test");
        }
    }

    public async Task ExerciseDALTest()
    {
        var exe = new Exercise()
        {
            SceneName = "Pendullum",
            Answers = new List<string>() {"1", "2", "3", "4"},
            CorrectAnswerIndex = 3,
            Question = "Ad Matai?" + DateTime.Now
        };

        await ServicesManager.GetDataAccessLayer().AddExerciseAsync(exe);

        var exersices = await ServicesManager.GetDataAccessLayer().GetExercisesAsync(exe.SceneName);

        if (exersices.Any(current => current.Question == exe.Question))
        {
            Debug.Log("ExerciseDALTest dal passed test");
        }
        else
        {
            Debug.LogError("ExerciseDALTest Dal failed test");
        }
    }

    public async Task StudentExerciseResultDALTest()
    {
        var exe = new StudentExerciseResult()
        {
            Question = "Ad Matai?" + DateTime.Now,
            AnsweringStudentId = "1111",
            isCorrect = true,
            StudentAnswer = "1"
        };

        await ServicesManager.GetDataAccessLayer().AddStudentExerciseResultAsync(exe);

        var statistics = await ServicesManager.GetDataAccessLayer().GetStudentStatisticsAsync(exe.AnsweringStudentId);

        if (statistics.Any(current => current.Question == exe.Question))
        {
            Debug.Log("StudentExerciseResultDALTest dal passed test");
        }
        else
        {
            Debug.LogError("StudentExerciseResultDALTest Dal failed test");
        }
    }
}