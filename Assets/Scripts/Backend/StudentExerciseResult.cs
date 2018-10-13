using System.Collections.Generic;

public class StudentExerciseResult: IFirebaseConvertable
{
    public string ExerciseName { get; set; }
    public string AnsweringStudentId { get; set; }
    public string Question { get; set; }
    public string StudentAnswer { get; set; }
    public bool isCorrect { get; set; }

    public void FromDictionary(IDictionary<string, object> data)
    {
        ExerciseName = (string)data[nameof(ExerciseName)];
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
            {nameof(ExerciseName), ExerciseName},
            {nameof(AnsweringStudentId), AnsweringStudentId},
            {nameof(Question), Question},
            {nameof(StudentAnswer), StudentAnswer},
            {nameof(isCorrect), isCorrect}
        };
    }

    public override string ToString()
    {
        return "Exercise Name: "+ ExerciseName + "Student ID: " + AnsweringStudentId + "\n, Question: " + Question
                + ",\n Student Answer: " + StudentAnswer + ",\n which is " + (isCorrect ? "Correct" : "Wrong");
    }
}