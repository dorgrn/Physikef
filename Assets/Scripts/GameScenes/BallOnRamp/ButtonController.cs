using Physikef.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace GameScenes.BallOnRamp
{
    public class ButtonController : MonoBehaviour
    {
        private bool gazedAt = false;
        private float progressBits;
        private float elapsedTime = 0f;
        private Slider fillBar;
        private const float millsecsToFill = 200f;
        private string value;
        private SceneController _sceneController;

        private void Awake()
        {
            Text label = GetComponentInChildren<Text>();
            value = label.text;
            _sceneController = FindObjectOfType<SceneController>();
        }

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

        private async void DoAction()
        {
            if (fillBar.value < 1f)
            {
                return;
            }

            await _sceneController.SubmitAnswer(value);
        }

        void FixedUpdate()
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