using UnityEngine;
using System.Linq;
using Attributes;
using Exercises;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameScenes.Balance
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager applicationManager;
        private SceneAttributes sceneAttributes = new SceneAttributes();
        private AttributContainer attributContainer;

        // questions
        [Inject] private IExercisePublisher m_exercisePublisher; // question supplier
        private Exercise m_sceneExercise; // current scene questions


        [SerializeField] private GameObject leftWeight;
        [SerializeField] private GameObject rightWeight;
        [SerializeField] private GameObject questionUI;

       // public Rigidbody leftObject, rightObject;

        void Awake()
        {
            //m_sceneExercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
            //attributContainer = applicationManager.GetAttributeContainer();
        }

        void Start()
        {
            leftWeight.SetActive(false);
            // wait for answer
            Physics.gravity = Vector3.zero;
            initAttributes();
        }


        public void SubmitAnswer(string answer)
        {
            if (m_sceneExercise.Answers.ToList()[m_sceneExercise.CorrectAnswerIndex].Equals(answer))
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
           // leftObject.mass = sceneAttributes.LeftWeight.Value;
            //rightObject.mass = sceneAttributes.LeftWeight.Value;
        }


        void initAttributes()
        {
            sceneAttributes.LeftWeight = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.leftWeight);
            sceneAttributes.RightWeight = attributContainer.GetAttributeFromEnum(AttributContainer.AttributeEnum.rightWeight);
        }

        public SceneAttributes GetSceneAttributes()
        {
            return sceneAttributes;
        }

        public static GameObject GetLeftWeight()
        {
            return GameObject.FindGameObjectWithTag("LeftWeight");
        }

        public static GameObject GetRightWeight()
        {
            return GameObject.FindGameObjectWithTag("RightWeight");
        }
    }
}