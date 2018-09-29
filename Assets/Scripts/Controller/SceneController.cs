using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        public Exercise m_SceneExercise;
        public FeedbackTextController m_FeedbackTextController;

        void Awake()
        {
            m_FeedbackTextController = FindObjectOfType<FeedbackTextController>();
        }

        public async Task SubmitAnswer(string answer)
        {
            m_SceneExercise =
                (await ServicesManager.GetDataAccessLayer().GetExercisesAsync("Pendulum"))
                .FirstOrDefault();
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
            string userid = ServicesManager.GetAuthManager().GetCurrentUserEmail();
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