using System.Collections.Generic;

public class Exercise : IFirebaseConvertable
{
    public string SceneName { get; set; }
    public string Question { get; set; }
    public IEnumerable<string> Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {nameof(SceneName), SceneName},
            {nameof(Question), Question},
            {nameof(Answers), Answers},
            {nameof(CorrectAnswerIndex), CorrectAnswerIndex}
        };
    }

    public void FromDictionary(IDictionary<string, object> data)
    {
        SceneName = (string)data[nameof(SceneName)];
        Question = (string)data[nameof(Question)];
        Answers = (IEnumerable<string>)data[nameof(Answers)];
        CorrectAnswerIndex = (int)data[nameof(CorrectAnswerIndex)];
    }

    public string GetTableName()
    {
        return "exercise";
    }
}