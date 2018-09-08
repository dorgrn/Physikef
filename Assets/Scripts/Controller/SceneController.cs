using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Exercises;
using GameScenes.Pendulum;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        [Inject] public readonly ApplicationManager m_ApplicationManager;
        [Inject] public readonly IExercisePublisher m_ExercisePublisher;
        public Exercise m_SceneExercise;
        public FeedbackTextController m_FeedbackTextController;

        void Awake()
        {
            m_FeedbackTextController = FindObjectOfType<FeedbackTextController>();
        }

        public async Task SubmitAnswer(string answer)
        {
            m_SceneExercise = await m_ExercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            bool isCorrectAnswer =
                m_SceneExercise.Answers.ElementAt(m_SceneExercise.CorrectAnswerIndex) == answer;

            Debug.Log("Submitting answer:" + answer);

            StartCoroutine(
                isCorrectAnswer ? m_FeedbackTextController.ShowCorrect() : m_FeedbackTextController.ShowWrong());

            StartCoroutine(StartScene());
            PostUserAnswer(answer, isCorrectAnswer);
        }

        public async void PostUserAnswer(string answer, bool isCorrect)
        {
            string userid = m_ApplicationManager.CurrentUser.userid;
            StudentExerciseResult studentExerciseResult = new StudentExerciseResult()
            {
                AnsweringStudentId = userid,
                isCorrect = isCorrect,
                Question = m_SceneExercise.Question,
                StudentAnswer = answer
            };
            await ServicesManager.GetDataAccessLayer().AddStudentExerciseResultAsync(studentExerciseResult);
        }

        protected abstract IEnumerator StartScene();
    }
}