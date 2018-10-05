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
    }


    public static void Quit()
    {
        Application.Quit();
    }
}