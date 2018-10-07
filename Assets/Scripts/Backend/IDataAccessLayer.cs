using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDataAccessLayer
{
    Task<IEnumerable<HomeWork>> GetHomeworkByUserEmailAsync(string userEmail);
    Task<HomeWork> GetHomeworkByNameAsync(string homeworkName);

    Task AddHomeworkAsync(HomeWork newHomework);
    Task AddExerciseAsync(Exercise newExercise);
    Task<IEnumerable<Exercise>> GetExercisesAsync(string sceneName);
    Task<IEnumerable<Exercise>> GetAllExercisesAsync();
    Task AddStudentExerciseResultAsync(StudentExerciseResult newExerciseResult);
    Task<IEnumerable<StudentExerciseResult>> GetStudentStatisticsAsync(string studentId);
    Task<IEnumerable<StudentExerciseResult>> GetAllStudentStatisticsAsync();
    Task AddUserAsync(User registeredUser);
    Task<User> GetUserByIdAsync(string userId);
    Task<User> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
}