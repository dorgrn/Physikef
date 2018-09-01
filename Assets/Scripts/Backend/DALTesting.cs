using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class DALTesting : MonoBehaviour {

    public async void TestDal()
    {
        await HomeworkDALTest();
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

        var getHw = await ServicesManager.GetDataAccessLayer().GetHomeWorkAsync("1111");

        if (getHw.Any(current => current.Name == hw.Name))
        {
            Debug.Log("Homework dal passed test");
        }
        else
        {
            Debug.LogError("Homework Dal failed test");
        }
    }
}
