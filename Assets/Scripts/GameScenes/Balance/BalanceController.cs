using UnityEngine;
using Attributes;
using Zenject;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Collections;
using GameScenes.Controller;
using Controllers;
using System.Linq;

namespace GameScenes.Balance
{
    public class BalanceController : SceneController
    {
        [Inject] private ApplicationManager applicationManager;
        private SceneAttributes sceneAttributes = new SceneAttributes();
        private AttributContainer attributContainer;
        [SerializeField] private GameObject questionUI;

        public GameObject seesaw;
        public GameObject leftWeight;
        public GameObject rightWeight;
       // public Text question;

        private readonly float seesawLengthSingleSide = 10f;

        void Start()
        {
            seesaw.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.GetComponent<Rigidbody>().isKinematic = true;
            rightWeight.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.SetActive(false);
            rightWeight.SetActive(false);

        }

        protected override IEnumerator StartScene()
        {
            parseExercise();
            yield return new WaitForSeconds(3);
            questionUI.SetActive(false);
            initComponents();

            leftWeight.SetActive(true);
            rightWeight.SetActive(true);
            seesaw.GetComponent<Rigidbody>().isKinematic = false;
            leftWeight.GetComponent<Rigidbody>().isKinematic = false;
            rightWeight.GetComponent<Rigidbody>().isKinematic = false;

        }

        private void parseExercise()
        {
            //Canvas c = questionUI.GetComponent<Canvas>();
            string question = m_SceneExercise.Question;
            // the order of numbers: right kg, right distance, left kg
            try
            {
                string[] numbers = Regex.Split(question, @"\D+");

                numbers = numbers.Where( str => !string.IsNullOrEmpty(str)).ToArray();
                int x = numbers.Length;
            if(numbers.Length == 3)
            {
                if(!string.IsNullOrEmpty(numbers[0]))
                {
                    sceneAttributes.RightWeight.Value = float.Parse(numbers[0]);
                    Debug.Log("right weight attribute got " + numbers[0]);
                }

                if (!string.IsNullOrEmpty(numbers[1]))
                {
                    sceneAttributes.RightDistance.Value = float.Parse(numbers[1]);
                    Debug.Log("right distance attribute got " + numbers[1]);
                }

                if (!string.IsNullOrEmpty(numbers[2]))
                {
                    sceneAttributes.LeftWeight.Value = float.Parse(numbers[2]);
                    Debug.Log("left weight attribute got " + numbers[2]);
                }
            }
            }
            catch (System.Exception e)
            {

            }
        }

        private void initComponents()
        {
            leftWeight.GetComponent<Rigidbody>().mass = sceneAttributes.LeftWeight.Value;
            rightWeight.GetComponent<Rigidbody>().mass = sceneAttributes.RightWeight.Value;

            // fix positions for the ui
            rightWeight.GetComponent<Rigidbody>().position = new Vector3(intervalValueMap(sceneAttributes.RightDistance.Value), 1.8f, 0);    
        }

        private float intervalValueMap(float value)
        {
            float ans = float.Parse(m_SceneExercise.Answers.ToList()[m_SceneExercise.CorrectAnswerIndex]);
            //float maxValue = Mathf.Max(seesawLengthSingleSide, sceneAttributes.RightDistance.Value, calculateRightAnswer());
            float maxValue = Mathf.Max(seesawLengthSingleSide, sceneAttributes.RightDistance.Value, float.Parse(m_SceneExercise.Answers.ToList()[m_SceneExercise.CorrectAnswerIndex]));
            if (maxValue > seesawLengthSingleSide)
            {
                return value * seesawLengthSingleSide / maxValue;
            }
            return value;
        }

        public SceneAttributes GetSceneAttributes()
        {
            return sceneAttributes;
        }

        public static GameObject GetLeftWeight()
        {
            return GameObject.FindGameObjectWithTag("LeftWeight");
        }

        public static GameObject GetRightDistance()
        {
            return GameObject.FindGameObjectWithTag("RightDistance");
        }

        public static GameObject GetRightWeight()
        {
            return GameObject.FindGameObjectWithTag("RightWeight");
        }

        private float calculateRightAnswer() => sceneAttributes.RightWeight.Value * sceneAttributes.RightDistance.Value / sceneAttributes.LeftWeight.Value;
    }
}

