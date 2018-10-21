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
using Physikef.GameScenes.Pendulum;

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
        public MonoBehaviour questionController;

        private bool isActive = false, parsed = false;

        private void initExercise()
        {
            if (questionController != null)
            {
                m_SceneExercise = questionController.GetComponent<QuestionTextController>().CurrentExercise;
            }
        }

        void Start()
        {
             initExercise();
             if (m_SceneExercise != null)
             {
                 parseExercise();
                int correctAns = int.Parse(Regex.Split(m_SceneExercise.Answers.ElementAt(m_SceneExercise.CorrectAnswerIndex), @"\D+")[0]);
                leftWeight.GetComponent<Rigidbody>().transform.localPosition = new Vector3(correctAns, 3.24f, 3f);
            }

            seesaw.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.GetComponent<Rigidbody>().isKinematic = true;
            rightWeight.GetComponent<Rigidbody>().isKinematic = true;
            leftWeight.SetActive(false);
            rightWeight.SetActive(true);           
        }

        void Update()
        {
            if (!parsed)
            {
                initExercise();
                if (m_SceneExercise != null)
                {
                    parseExercise();
                    int correctAns = int.Parse(Regex.Split(m_SceneExercise.Answers.ElementAt(m_SceneExercise.CorrectAnswerIndex), @"\D+")[0]);
                    leftWeight.GetComponent<Rigidbody>().transform.localPosition = new Vector3(-correctAns, 3.24f, 3f);
                    leftWeight.SetActive(false);
                    parsed = true;
                }
               
            }
        }

        private void parseExercise()
        {
           
            // the order of numbers: right kg[0], right distance[1], left kg[2]
            try
            {
                string question = m_SceneExercise.Question;

                string[] numbers = Regex.Split(question, @"\D+");

                numbers = numbers.Where( str => !string.IsNullOrEmpty(str)).ToArray();
                int x = numbers.Length;
                if(numbers.Length == 3)
                {

                    rightWeight.GetComponent<Rigidbody>().mass = float.Parse(numbers[RIGHT_KG]);
                    rightWeight.GetComponent<Rigidbody>().transform.localPosition = new Vector3(intervalValueMap(float.Parse(numbers[RIGHT_DIST])), 3.24f, 3f);

                    leftWeight.GetComponent<Rigidbody>().mass = float.Parse(numbers[LEFT_KG]);
                    int correctAns = int.Parse(Regex.Split(m_SceneExercise.Answers.ElementAt(m_SceneExercise.CorrectAnswerIndex), @"\D+")[0]);
                   leftWeight.GetComponent<Rigidbody>().transform.localPosition = new Vector3(-correctAns, 3.24f, 3f);
                }
            }
            catch (System.Exception e)
            {
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

    }
}

