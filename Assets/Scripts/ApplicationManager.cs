using Attributes;
using UnityEngine;

public class ApplicationManager
{
    public User CurrentUser { get; set; }
    public string CurrentScene { get; set; }
    public string CurrentExercise { get; set; }

    public bool IsHardCodedAnswers { get; } = true;

    protected ApplicationManager()
    {
        initCurrentUser();
    }

    private async void initCurrentUser()
    {
        // TODO: place holder
//        CurrentUser = await ServicesManager.GetDataAccessLayer().GetUserByIdAsync("olga_abir@yahoo.com");

    }


    public static void Quit()
    {
        Application.Quit();
    }
}