using System.Collections.Generic;
using System.Linq;

public class Exercise : IFirebaseConvertable
{
    public string ExerciseName { get; set; }
    public string SceneName { get; set; }
    public string Question { get; set; }
    public IEnumerable<string> Answers { get; set; }
    public int CorrectAnswerIndex { get; set; }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {nameof(ExerciseName), ExerciseName},
            {nameof(SceneName), SceneName},
            {nameof(Question), Question},
            {nameof(Answers), Answers.ToFirebaseDictionary()},
            {nameof(CorrectAnswerIndex), CorrectAnswerIndex}
        };
    }

    public void FromDictionary(IDictionary<string, object> data)
    {
        var type = data[nameof(CorrectAnswerIndex)].GetType();

        ExerciseName = (string)data[nameof(ExerciseName)];
        SceneName = (string) data[nameof(SceneName)];
        Question = (string) data[nameof(Question)];
        Answers = ((List<object>) data[nameof(Answers)]).Cast<string>();
        CorrectAnswerIndex = (int) (long) data[nameof(CorrectAnswerIndex)];
    }

    public string GetTableName()
    {
        return "exercise";
    }
}