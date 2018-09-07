using UnityEngine;

public class ApplicationManager
{
    public string ChosenScene { get; set; }
    public string ChosenExercise { get; set; }
    public bool IsHardCodedAnswers { get; private set; }

    protected ApplicationManager(bool isHardCodedAnswers = true)
    {
        IsHardCodedAnswers = isHardCodedAnswers;
    }

    public static void Quit()
    {
        Application.Quit();
    }
}