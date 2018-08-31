using System.Collections.Generic;

public class DataAccessLayer : IDataAccessLayer
{
    public IEnumerable<HomeWork> GetHomeWork(string userID)
    {
        /*
        var allHomeworks =  m_FirebaseClient.Child("homework").OnceAsync<HomeWork>();

        return allHomeworks.Where(hw => hw.Object.Students.Contains(userID)).Select(hw => hw.Object);
        */
        throw new System.NotImplementedException();
    }

    public void AddHomework(string creator,string name, string sceneName, IEnumerable<string> studentIDs)
    {
        /*
        var homework = new HomeWork()
        {
            CreatorName = creator,
            Name = name,
            SceneName = sceneName,
            Students = studentIDs
        };

        await m_FirebaseClient.Child("homework").PostAsync(homework);
        */
    }

    public IEnumerable<Exercise> GetExercises(string sceneName)
    {
        /*
        var allExercises = await m_FirebaseClient.Child("exercise").OnceAsync<Exercise>();

        return allExercises.Where(exe => exe.Object.SceneName == sceneName).Select(exe => exe.Object);
        */
        throw new System.NotImplementedException();
    }

    public void AddExercise(string sceneName, string question, IEnumerable<string> answers, int correctAnswerIndex)
    {
        /*
        var exercise = new Exercise()
        {
            SceneName = sceneName,
            Question = question,
            Answers = answers,
            CorrectAnswerIndex = correctAnswerIndex
        };

        await m_FirebaseClient.Child("exercise").PostAsync(exercise);
        */
    }

    public void AddStudentExerciseResult(string answeringStudentId, string question, string studentAnswer, bool isCorrect)
    {
        /*
        var studentExerciseResult = new StudentExerciseResult()
        {
            AnsweringStudentId = answeringStudentId,
            Question = question,
            StudentAnswer = studentAnswer,
            isCorrect = isCorrect
        };

        await m_FirebaseClient.Child("statistics").PostAsync(studentExerciseResult);
        */
    }

    public IEnumerable<StudentExerciseResult> GetStudentStatistics(string studentId)
    {
        /*
        var allStudentStatistics = await m_FirebaseClient.Child("statistics").OnceAsync<StudentExerciseResult>();

        return allStudentStatistics.Where(result => result.Object.AnsweringStudentId == studentId).Select(result => result.Object);
        */
        throw new System.NotImplementedException();
    }
}
