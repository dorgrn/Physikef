using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DataAccessLayer : IDataAccessLayer
{
    private readonly DatabaseReference _databaseRef;

    public DataAccessLayer()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://physikef-18062.firebaseio.com/");
        _databaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public async Task<IEnumerable<HomeWork>> GetHomeWorkAsync(string userID)
    {
        var allHomeworks = await GetDataFromFirebaseDBAsync("homework");
        return allHomeworks.Cast<HomeWork>().Where(hw => hw.Students.Contains(userID));
    }

    public async Task AddHomeworkAsync(HomeWork newHomework)
    {
        await AddDataToFirebaseDBAsync(newHomework);
    }

    public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
    {
        var allExercises = await GetDataFromFirebaseDBAsync("exercise");
        return allExercises.Cast<Exercise>();
    }

    public async Task<IEnumerable<Exercise>> GetExercisesAsync(string sceneName)
    {
        var allExercises = await GetAllExercisesAsync();
        return allExercises.Where(exe => exe.SceneName == sceneName);
    }

    public async Task AddExerciseAsync(Exercise newExercise)
    {
        await AddDataToFirebaseDBAsync(newExercise);
    }

    public async Task AddStudentExerciseResultAsync(StudentExerciseResult newExerciseResult)
    {
        await AddDataToFirebaseDBAsync(newExerciseResult);
    }

    public async Task<IEnumerable<StudentExerciseResult>> GetStudentStatisticsAsync(string studentId)
    {
        var allStudentStatistics = await GetAllStudentStatisticsAsync();
        return allStudentStatistics.Where(result => result.AnsweringStudentId == studentId);
    }

    public async Task<IEnumerable<StudentExerciseResult>> GetAllStudentStatisticsAsync()
    {
        var stats = await GetDataFromFirebaseDBAsync("statistics");
        return stats.Cast<StudentExerciseResult>();
    }

    public async Task AddUserAsync(User newUser)
    {
        await AddDataToFirebaseDBAsync(newUser);
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        var allUsers = await GetAllUsersAsync();
        return allUsers.FirstOrDefault(user => user.userid == userId);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var allUsers = await GetAllUsersAsync();
        return allUsers.FirstOrDefault(user => user.email == email);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var allUsers = await GetDataFromFirebaseDBAsync("users");
        return allUsers.Cast<User>();
    }

    private async Task AddDataToFirebaseDBAsync(IFirebaseConvertable dataObject)
    {
        var key = _databaseRef.Child(dataObject.GetTableName()).Push().Key;
        Dictionary<string, object> details = new Dictionary<string, object>()
        {
            {key, dataObject.ToDictionary()}
        };

        await _databaseRef.Child(dataObject.GetTableName()).UpdateChildrenAsync(details);
    }

    private async Task<IEnumerable<IFirebaseConvertable>> GetDataFromFirebaseDBAsync(string tableName)
    {
        var result = await _databaseRef.Child(tableName).GetValueAsync();

        var objects = new List<IFirebaseConvertable>();

        foreach (var dataSnapshot in result.Children)
        {
            var ourDictionary = new Dictionary<string, object>();
            foreach (var dataSnapshotChild in dataSnapshot.Children)
            {
                ourDictionary.Add(dataSnapshotChild.Key, dataSnapshotChild.Value);
            }

            var firebaseObject = Provider(tableName);
            firebaseObject.FromDictionary(ourDictionary);
            objects.Add(firebaseObject);
        }

        return objects;
    }

    private IFirebaseConvertable Provider(string tableName)
    {
        if (tableName == new User().GetTableName())
        {
            return new User();
        }

        if (tableName == new HomeWork().GetTableName())
        {
            return new HomeWork();
        }

        if (tableName == new Exercise().GetTableName())
        {
            return new Exercise();
        }

        if (tableName == new StudentExerciseResult().GetTableName())
        {
            return new StudentExerciseResult();
        }

        throw new NotSupportedException();
    }
}