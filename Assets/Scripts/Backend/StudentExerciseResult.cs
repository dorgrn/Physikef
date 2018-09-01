using System.Collections.Generic;

public class StudentExerciseResult: IFirebaseConvertable
{
    public string AnsweringStudentId { get; set; }
    public string Question { get; set; }
    public string StudentAnswer { get; set; }
    public bool isCorrect { get; set; }

    public void FromDictionary(IDictionary<string, object> data)
    {
        AnsweringStudentId = (string)data[nameof(AnsweringStudentId)];
        Question = (string)data[nameof(Question)];
        StudentAnswer = (string)data[nameof(StudentAnswer)];
        isCorrect = (bool)data[nameof(isCorrect)];
    }

    public string GetTableName()
    {
        return "statistics";
    }

    public IDictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {nameof(AnsweringStudentId), AnsweringStudentId},
            {nameof(Question), Question},
            {nameof(StudentAnswer), StudentAnswer},
            {nameof(isCorrect), isCorrect}
        };
    }

    public override string ToString()
    {
        return "Student ID: " + AnsweringStudentId + "\n, Question: " + Question
                + ",\n Student Answer: " + StudentAnswer + ",\n which is " + (isCorrect ? "Correct" : "Wrong");
    }
}