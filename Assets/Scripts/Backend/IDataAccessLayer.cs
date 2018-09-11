using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataAccessLayer
{
    Task<IEnumerable<HomeWork>> GetHomeWorkAsync(string userID);
    Task AddHomeworkAsync(HomeWork newHomework);
    Task AddExerciseAsync(Exercise newExercise);
    Task<IEnumerable<Exercise>> GetExercisesAsync(string sceneName);
    Task<IEnumerable<Exercise>> GetAllExercisesAsync();
    Task AddStudentExerciseResultAsync(StudentExerciseResult newExerciseResult);
    Task<IEnumerable<StudentExerciseResult>> GetStudentStatisticsAsync(string studentId);
    Task AddUserAsync(User registeredUser);
    Task<User> GetUserAsync(string userId);
    Task<IEnumerable<User>> GetAllUsers();
}
