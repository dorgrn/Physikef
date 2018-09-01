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

    public async Task AddUserAsync(User newUser)
    {
        await AddDataToFirebaseDBAsync(newUser);
    }

    public async Task<User> GetUserAsync(string userEmail)
    {
        var allUsers = await GetDataFromFirebaseDBAsync("users");
        return (User) allUsers.First(user => ((User) user).email == userEmail);
    }

    private async Task AddDataToFirebaseDBAsync(IFirebaseConvertable dataObject)
    {
        var key = _databaseRef.Child(dataObject.GetTableName()).Push().Key;
        Dictionary<string, object> details = new Dictionary<string, object>()
        {
            {key , dataObject.ToDictionary()}
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

        throw new NotSupportedException();
    }
}
