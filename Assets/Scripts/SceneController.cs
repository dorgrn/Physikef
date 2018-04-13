using System;
using System.Collections;
using UnityEngine;

namespace Physikef
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] float gravity = 30f;
        [SerializeField] float massMult = 1f;
        [SerializeField] float dragMult;
        [SerializeField] float angularDragMult;
        [SerializeField] GameObject target;
        internal static bool isPaused;
        internal static bool isAnswered;
        private bool firstAnswer = false;
        internal static int answerValue;

        private const int WAIT_SECONDS = 1;
        private Vector3 originalTargetLocation;
        [SerializeField] GameObject[] flares;

        // Use this for initialization
        void Start()
        {
            //Physics.gravity = new Vector3(0, -gravity, 0);
            isPaused = true;
            target = getTarget();
            originalTargetLocation = target.GetComponent<Transform>().position;
            StartCoroutine(ShowPreview());
        }

        IEnumerator ShowPreview()
        {
            yield return new WaitForSeconds(WAIT_SECONDS);

            StopScene();

            Debug.Log("Look at scene!");
            // look at scene

            StartScene();

            Debug.Log("Answer the question please!");
            // TODO: indicator to answer question


        }

        void CheckAnswer()
        {
            float distance = getTargetDistanceFromRamp();
            if (distance >= answerValue)
            {
                Debug.Log("Good job!");
            }
            else
            {
                Debug.Log("Too bad!");
            }

            StopScene();

            ResetScene();

            ShowFlares();

            HideQuestion();

            StartScene();
        }

        private void HideQuestion()
        {
            var question = GameObject.FindGameObjectWithTag("Question");
            question.SetActive(false);
        }

        void ShowFlares()
        {
            foreach (GameObject flare in flares)
            {
                flare.SetActive(true);
            }
        }

        void StopScene()
        {
            target.GetComponent<Rigidbody>().useGravity = false;
            isPaused = true;
        }

        void ResetScene()
        {
            target.GetComponent<Transform>().position = originalTargetLocation;
        }

        // Update is called once per frame
        void Update()
        {
            if (isAnswered && !firstAnswer) 
            {
                isAnswered = false;
                firstAnswer = true;
                CheckAnswer();
            }
        }

        static public GameObject getTarget()
        {
            return GameObject.FindGameObjectWithTag("Target");
        }

        static public float getTargetDistanceFromRamp()
        {
            GameObject ramp = GameObject.FindGameObjectWithTag("Ramp");
            GameObject target = getTarget();

            if (!ramp || !target)
            {
                Debug.LogErrorFormat("Couldn't find Target {0} or Ramp {1}", target, ramp);
                return 0;
            }

            return Vector3.Distance(ramp.transform.position, target.transform.position);
        }

        public static void StartScene()
        {
            if (!isPaused)
            {
                return;
            }

            GameObject target = getTarget();
            if (!target)
            {
                Debug.LogError("No target in StartScene");
            }

            Rigidbody rb = target.GetComponent<Rigidbody>();
            rb.useGravity = true;
            isPaused = false;

        }
    }

}
