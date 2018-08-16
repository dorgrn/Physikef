using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class ButtonController : MonoBehaviour
    {
        private bool gazedAt = false;
        private float progressBits;
        private float elapsedTime = 0f;
        private Slider fillBar;
        [SerializeField] float millsecsToFill = 200f;
        [SerializeField] float value = 0f;
        [SerializeField] private SceneEnum sceneEnum;


        enum SceneEnum
        {
            Back,
            BallOnRamp,
            Pendulum
        };


        // Use this for initialization
        void Start()
        {
            progressBits = millsecsToFill / 1000f;
            fillBar = GetComponent<Slider>();
        }

        public void SetGazedAt(bool gazedAt)
        {
            Debug.Log(string.Format("{0} Gazed at to {1}", this, gazedAt));
            this.gazedAt = gazedAt;
        }

        public void DoAction()
        {
            if (fillBar.value < 1f)
            {
                return;
            }

            switch (sceneEnum)
            {
                case SceneEnum.Back:
                    SceneManager.LoadScene("MainMenu");
                    break;
                case SceneEnum.BallOnRamp:
                    SceneManager.LoadScene("BallOnRamp");
                    break;
                case SceneEnum.Pendulum:
                    SceneManager.LoadScene("Penudulum");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (fillBar.value >= 1f)
            {
                DoAction();
            }

            if (!gazedAt)
            {
                fillBar.value = 0f;
                return;
            }

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= progressBits && fillBar.value < 1f)
            {
                elapsedTime = elapsedTime % progressBits;
                fillBar.value += progressBits;
            }
        }
    }
}