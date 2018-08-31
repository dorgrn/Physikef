using System.Collections.Generic;

public class Exercise
{
    public string SceneName { get; set; }
    public string Question { get; set; }
    public IEnumerable<string> Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }
}