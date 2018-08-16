using Attributes;
using Questions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Controller
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager applicationManager;
        private SceneAttributes sceneAttributes = new SceneAttributes();
        private AttributContainer attributContainer;

        // questions
        [Inject] private IQuestionPublisher questionPublisher; // question supplier
        private Question sceneQuestion; // current scene questions


        [SerializeField] private GameObject target;

        void Awake()
        {
            sceneQuestion = questionPublisher.GetQuestionForScene(SceneManager.GetActiveScene().name);
            attributContainer = applicationManager.GetAttributeContainer();
        }

        void Start()
        {
            initAttributes();
            initComponents();
        }

        void initComponents()
        {
            Vector3 currentPostion = target.transform.position;
            Rigidbody rb = target.GetComponent<Rigidbody>();

            // set height
            target.transform.position = new Vector3(currentPostion.x, sceneAttributes.Height.Value, currentPostion.z);

            // set mass
            rb.mass = sceneAttributes.MassMult.Value;

            // set velocity
            rb.velocity = Vector3.forward * sceneAttributes.Velocity.Value;

            // set Gravity
            Physics.gravity = Physics.gravity * sceneAttributes.Gravity.Value;

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