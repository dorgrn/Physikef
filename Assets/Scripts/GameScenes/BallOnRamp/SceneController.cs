using Attributes;
using Exercises;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.BallOnRamp
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager m_ApplicationManager;
        private SceneAttributes m_SceneAttributes = new SceneAttributes();

        // questions
        [Inject] private IExercisePublisher m_ExercisePublisher; // question supplier
        private Exercise m_SceneExercise; // current scene questions


        [SerializeField] private GameObject m_Target;
        [SerializeField] private GameObject m_QuestionUi;

        private readonly Vector3 m_PhysicsNormal = new Vector3(0f, -9.8f, 0f);

        void Awake()
        {
            m_SceneExercise = m_ExercisePublisher.GetExercisesForScene(SceneManager.GetActiveScene().name)[0];
//            m_AttributContainer = m_ApplicationManager.GetAttributeContainer();
        }

        void Start()
        {
            // wait for answer
            Physics.gravity = Vector3.zero;
            initAttributes();
        }


        public void SubmitAnswer(string answer)
        {
            if (m_SceneExercise.Answer.Equals(answer))
            {
                Debug.Log("Correct!");
                // TODO: answer correct
            }
            else
            {
                Debug.Log("Incorrect!");
                // TODO: answer not correct
            }

            m_QuestionUi.SetActive(false);
            initComponents();
        }


        void initComponents()
        {
            Vector3 currentPostion = m_Target.transform.position;
            Rigidbody rb = m_Target.GetComponent<Rigidbody>();
            Transform rampTransform = GetRamp().transform;

            // set height
            m_Target.transform.position = currentPostion +
                                        new Vector3(0, m_SceneAttributes.Height.Value, 0);

            // set mass
            rb.mass = rb.mass * m_SceneAttributes.MassMult.Value;

            // set Gravity
            Physics.gravity = m_PhysicsNormal; //* sceneAttributes.Gravity.Value;

            // set drag
            rb.drag = m_SceneAttributes.DragMult.Value;
        }


        void initAttributes()
        {
//            m_SceneAttributes.Gravity = m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.Gravity);
//            m_SceneAttributes.Height = m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.Height);
//            m_SceneAttributes.DragMult = m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.Friction);
//            m_SceneAttributes.Velocity = m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.Velocity);
//            m_SceneAttributes.AngularDragMult =
//                m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.angularDragMult);
//            m_SceneAttributes.MassMult = m_AttributContainer.GetAttributeFromEnum(AttributeContainer.AttributeEnum.Mass);
        }

        public SceneAttributes GetSceneAttributes()
        {
            return m_SceneAttributes;
        }

        public static GameObject GetRamp()
        {
            return GameObject.FindGameObjectWithTag("Ramp");
        }

        public static GameObject GetTarget()
        {
            return GameObject.FindGameObjectWithTag("Target");
        }

        public static float GetTargetDistanceFromRamp()
        {
            GameObject ramp = GameObject.FindGameObjectWithTag("Ramp");
            GameObject target = GameObject.FindGameObjectWithTag("Target");

            if (!ramp || !target)
            {
                return 0;
            }

            return Vector3.Distance(ramp.transform.position, target.transform.position);
        }
    }
}