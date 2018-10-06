using Physikef.GameScenes.DirectionPointer;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Physikef.Controller
{
    public class SceneController : MonoBehaviour
    {
        private readonly float START_SCENE_DELAY_SECONDS = 1;
        protected Exercise m_SceneExercise;
        protected FeedbackTextController m_FeedbackTextController;
        protected DirectionPointer m_DirectionPointer;
        protected GameObject m_TargetAction;
        [SerializeField] protected GameObject m_QuestionUi;
        [SerializeField] protected MonoBehaviour m_SceneActionScript;

        void Awake()
        {
            m_FeedbackTextController = FindObjectOfType<FeedbackTextController>();
            m_TargetAction = GameObject.FindGameObjectWithTag("Target");
        }

        void Start()
        {
            StartCoroutine(SwitchToScene.SwapToVR());
            m_DirectionPointer = FindObjectOfType<DirectionPointer>();
            m_DirectionPointer.SetTarget(m_QuestionUi);
        }

        public async Task SubmitAnswer(string answer)
        {
            m_SceneExercise =
                (await ServicesManager.GetDataAccessLayer().GetExercisesAsync(SceneManager.GetActiveScene().name))
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

        virtual protected IEnumerator StartScene()
        {
            yield return new WaitForSeconds(START_SCENE_DELAY_SECONDS);
            m_QuestionUi.SetActive(false);
            m_SceneActionScript.enabled = true;
            m_DirectionPointer.SetTarget(m_TargetAction);
        }
    }
}