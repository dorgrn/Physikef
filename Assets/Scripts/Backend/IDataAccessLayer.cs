using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataAccessLayer
{
    IEnumerable<HomeWork> GetHomeWork(string userID);
    void AddHomework(string creator, string name, string sceneName, IEnumerable<string> userIDs);
    void AddExercise(string sceneName, string question, IEnumerable<string> answers, int correctAnswerIndex);
    IEnumerable<Exercise> GetExercises(string sceneName);
    void AddStudentExerciseResult(string answeringStudentId, string question, string studentAnswer, bool isCorrect);
    IEnumerable<StudentExerciseResult> GetStudentStatistics(string studentId);
    Task AddUserAsync(User registeredUser);
}
