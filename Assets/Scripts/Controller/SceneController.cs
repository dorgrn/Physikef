using Physikef.GameScenes.DirectionPointer;
using Physikef.GameScenes.Pendulum;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Physikef.Controller
{
    public class SceneController : MonoBehaviour
    {
        protected Exercise m_SceneExercise;
        protected FeedbackTextController m_FeedbackTextController;
        protected DirectionPointer m_DirectionPointer;
        protected GameObject m_TargetAction;
        [SerializeField] protected GameObject m_QuestionUi;
        [SerializeField] protected MonoBehaviour m_SceneActionScript;
        private bool m_ShouldStartScene;

        void Awake()
        {
            m_FeedbackTextController = FindObjectOfType<FeedbackTextController>();
            m_TargetAction = GameObject.FindGameObjectWithTag("Target");
        }

        void Start()
        {
            StartCoroutine(SceneSwitcher.SwapToVR());
            m_DirectionPointer = FindObjectOfType<DirectionPointer>();
            m_DirectionPointer.SetTarget(m_QuestionUi);
        }

        public async Task SubmitAnswer(string answer)
        {
            m_SceneExercise =
                await QuestionTextController.GetExerciseForStudentAsync();
            bool isCorrectAnswer =
                m_SceneExercise.Answers.ElementAt(m_SceneExercise.CorrectAnswerIndex) == answer;

            Debug.Log("Submitting answer:" + answer);

            StartCoroutine(
                isCorrectAnswer ? m_FeedbackTextController.ShowCorrect() : m_FeedbackTextController.ShowWrong());

            if (isUserAnonymous())
            {
                // simulate posting answer to allow trigger StartScene
                triggerShouldStartScene();
                return;
            }

            await PostUserAnswer(answer, isCorrectAnswer);
        }

        public async Task PostUserAnswer(string answer, bool isCorrect)
        {
            string userid = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            m_DirectionPointer.SetTarget(m_TargetAction);
            if (isUserAnonymous() || m_ShouldStartScene)
            {
                return;
            }

            triggerShouldStartScene();

            StudentExerciseResult studentExerciseResult = new StudentExerciseResult()
            {
                AnsweringStudentId = userid,
                isCorrect = isCorrect,
                Question = m_SceneExercise.Question,
                StudentAnswer = answer
            };
            await ServicesManager.GetDataAccessLayer().AddStudentExerciseResultAsync(studentExerciseResult);
        }

        // notice: StartScene is triggered by a GvrRayCast target that stands in front of target.
        // this is to allow the user to look around before the scene starts
        protected void StartScene()
        {
            m_QuestionUi.SetActive(false);
            m_SceneActionScript.enabled = true;
        }

        public void StartSceneConditionally()
        {
            if (m_ShouldStartScene)
            {
                StartScene();
            }
        }

        private bool isUserAnonymous()
        {
            return string.IsNullOrEmpty(ServicesManager.GetAuthManager().GetCurrentUserEmail());
        }

        private void triggerShouldStartScene()
        {
            m_ShouldStartScene = true;
            m_DirectionPointer.SetTarget(m_TargetAction);
        }
    }
}