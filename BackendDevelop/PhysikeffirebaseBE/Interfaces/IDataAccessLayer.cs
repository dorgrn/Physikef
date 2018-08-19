using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhysikeffirebaseBE.Interfaces
{
    public interface IDataAccessLayer
    {
        Task<IEnumerable<HomeWork>> GetHomeWorkAsync(string userID);
        Task AddHomeworkAsync(string creator, string name, string sceneName, IEnumerable<string> userIDs);
        Task AddExerciseAsync(string sceneName, string question, IEnumerable<string> answers, int correctAnswerIndex);
        Task<IEnumerable<Exercise>> GetExercisesAsync(string sceneName);
        Task AddStudentExerciseResultAsync(string answeringStudentId, string question, string studentAnswer, bool isCorrect);
        Task<IEnumerable<StudentExerciseResult>> GetStudentStatisticsAsync(string studentId);

    }
}