using Attributes;
using Exercises;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.BallOnRamp
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager applicationManager;
        private SceneAttributes sceneAttributes = new SceneAttributes();
        private AttributContainer attributContainer;

        // questions
        [Inject] private IExercisePublisher m_exercisePublisher; // question supplier
        private Exercise m_sceneExercise; // current scene questions


        [SerializeField] private GameObject target;
        [SerializeField] private GameObject questionUI;

        private Vector3 physicsNormal = new Vector3(0f, -9.8f, 0f);

        void Awake()
        {
            m_sceneExercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            attributContainer = applicationManager.GetAttributeContainer();
        }

        void Start()
        {
            // wait for answer
            Physics.gravity = Vector3.zero;
            initAttributes();
        }


        public void SubmitAnswer(string answer)
        {
            if (m_sceneExercise.Answer.Equals(answer))
            {
                Debug.Log("Correct!");
                // TODO: answer correct
            }
            else
            {
                Debug.Log("Incorrect!");
                // TODO: answer not correct
            }

            questionUI.SetActive(false);
            initComponents();
        }


        void initComponents()
        {
            Vector3 currentPostion = target.transform.position;
            Rigidbody rb = target.GetComponent<Rigidbody>();
            Transform rampTransform = GetRamp().transform;

            // set height
            target.transform.position = currentPostion +
                                        new Vector3(0, sceneAttributes.Height.Value, 0);

            // set mass
            rb.mass = rb.mass * sceneAttributes.MassMult.Value;

            // set Gravity
            Physics.gravity = physicsNormal; //* sceneAttributes.Gravity.Value;

            // set drag
            rb.drag = sceneAttributes.DragMult.Value;
        }


        void initAttributes()
        {
            sceneAttributes.Gravity = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.Gravity);
            sceneAttributes.Height = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.Height);
            sceneAttributes.DragMult = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.Friction);
            sceneAttributes.Velocity = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.Velocity);
            sceneAttributes.AngularDragMult =
                attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.angularDragMult);
            sceneAttributes.MassMult = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.Mass);
        }

        public SceneAttributes GetSceneAttributes()
        {
            return sceneAttributes;
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