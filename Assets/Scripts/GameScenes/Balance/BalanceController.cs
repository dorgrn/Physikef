using UnityEngine;
using Attributes;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Collections;
using Physikef.Controller;
using Controllers;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using Physikef.GameScenes.Balance;

namespace GameScenes.Balance
{
    public class BalanceController  : MonoBehaviour
    {
        public GameObject seesaw;
        public GameObject leftWeight;
        public GameObject rightWeight;
        private Exercise m_SceneExercise;

        private readonly int RIGHT_KG = 0;
        private readonly int RIGHT_DIST = 1;
        private readonly int LEFT_KG = 2;
        

        private readonly float seesawLengthSingleSide = 10f;
        public QuestionTextController questionController;

        private void initExercise()
        {
            m_SceneExercise = questionController.sceneExercise;
        }

        void Start()
        {
          //this.enabled = false;
            seesaw.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.GetComponent<Rigidbody>().isKinematic = true;
            rightWeight.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.SetActive(false);
            rightWeight.SetActive(true);
        }

        private void Update()
        {
            if(this.enabled)
            { 
                initExercise();
                parseExercise();
                leftWeight.SetActive(true);
                rightWeight.SetActive(true);
                seesaw.GetComponent<Rigidbody>().isKinematic = false;
                leftWeight.GetComponent<Rigidbody>().isKinematic = false;
                rightWeight.GetComponent<Rigidbody>().isKinematic = false;
            }
        }

        private void parseExercise()
        {
            string question = m_SceneExercise.Question;
            // the order of numbers: right kg[0], right distance[1], left kg[2]
            try
            {
                string[] numbers = Regex.Split(question, @"\D+");

                numbers = numbers.Where( str => !string.IsNullOrEmpty(str)).ToArray();
                int x = numbers.Length;
                if(numbers.Length == 3)
                {
                    rightWeight.GetComponent<Rigidbody>().mass = float.Parse(numbers[RIGHT_KG]);
                    rightWeight.GetComponent<Rigidbody>().position = new Vector3(intervalValueMap(float.Parse(numbers[RIGHT_DIST])), 1.8f, 0);
                    leftWeight.GetComponent<Rigidbody>().mass = float.Parse(numbers[LEFT_KG]);
                }
            }
            catch (System.Exception e)
            {
                // ??
            }
        }

        private float intervalValueMap(float value)
        {
            String ansString = m_SceneExercise.Answers.ToList()[m_SceneExercise.CorrectAnswerIndex];
            float ans = float.Parse(ansString.Remove(ansString.IndexOf(' ')));
            float maxValue = Mathf.Max(seesawLengthSingleSide, rightWeight.GetComponent<Rigidbody>().position.x, ans);
            if (maxValue > seesawLengthSingleSide)
            {
                return value * seesawLengthSingleSide / maxValue;
            }
            return value;
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

        private float calculateRightAnswer() => rightWeight.GetComponent<Rigidbody>().mass * rightWeight.GetComponent<Rigidbody>().position.x / leftWeight.GetComponent<Rigidbody>().mass;
    }
}

