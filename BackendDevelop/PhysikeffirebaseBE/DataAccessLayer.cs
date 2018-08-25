using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using PhysikeffirebaseBE.Interfaces;

namespace PhysikeffirebaseBE
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly FirebaseClient m_FirebaseClient;

        public DataAccessLayer()
        {
            m_FirebaseClient = new FirebaseClientFactory().CreateClient();
        }

        public async Task<IEnumerable<HomeWork>> GetHomeWorkAsync(string userID)
        {
            var allHomeworks = await m_FirebaseClient.Child("homework").OnceAsync<HomeWork>();

            return allHomeworks.Where(hw => hw.Object.Students.Contains(userID)).Select(hw => hw.Object);
        }

        public async Task AddHomeworkAsync(string creator,string name, string sceneName, IEnumerable<string> studentIDs)
        {
            var homework = new HomeWork()
            {
                CreatorName = creator,
                Name = name,
                SceneName = sceneName,
                Students = studentIDs
            };

            await m_FirebaseClient.Child("homework").PostAsync(homework);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync(string sceneName)
        {
            var allExercises = await m_FirebaseClient.Child("exercise").OnceAsync<Exercise>();

            return allExercises.Where(exe => exe.Object.SceneName == sceneName).Select(exe => exe.Object);
        }

        public async Task AddExerciseAsync(string sceneName, string question, IEnumerable<string> answers, int correctAnswerIndex)
        {
            var exercise = new Exercise()
            {
                SceneName = sceneName,
                Question = question,
                Answers = answers,
                CorrectAnswerIndex = correctAnswerIndex
            };

            await m_FirebaseClient.Child("exercise").PostAsync(exercise);
        }

        public async Task AddStudentExerciseResultAsync(string answeringStudentId, string question, string studentAnswer, bool isCorrect)
        {
            var studentExerciseResult = new StudentExerciseResult()
            {
                AnsweringStudentId = answeringStudentId,
                Question = question,
                StudentAnswer = studentAnswer,
                isCorrect = isCorrect
            };

            await m_FirebaseClient.Child("statistics").PostAsync(studentExerciseResult);
        }

        public async Task<IEnumerable<StudentExerciseResult>> GetStudentStatisticsAsync(string studentId)
        {
            var allStudentStatistics = await m_FirebaseClient.Child("statistics").OnceAsync<StudentExerciseResult>();

            return allStudentStatistics.Where(result => result.Object.AnsweringStudentId == studentId).Select(result => result.Object);
        }
    }
}
