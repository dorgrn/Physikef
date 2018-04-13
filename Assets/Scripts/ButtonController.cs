using System.Linq;
using UnityEngine;
using UnityEngine.UI;
namespace Physikef
{
    public class ButtonController : MonoBehaviour
    {
        Slider fillBar;
        [SerializeField] float millsecsToFill = 200f;
        [SerializeField] int value = 0;
        private bool gazedAt = false;
        private float elapsedTime = 0f;
        private float sliderProgressAmount;

        void Start()
        {
            sliderProgressAmount = millsecsToFill / 1000f;
            fillBar = GetComponent<Slider>();
        }

        public void SetGazedAt(bool gazedAt)
        {
            Debug.Log(string.Format("{0} Gazed at to {1}", this, gazedAt));
            this.gazedAt = gazedAt;
        }

        public void DoAction()
        {
            SceneController.answerValue = value;
            SceneController.isAnswered = true;
        }



        void Update()
        {
            CheckSliderValue();
        }

        private void CheckSliderValue()
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
            if (elapsedTime >= sliderProgressAmount && fillBar.value < 1f)
            {
                elapsedTime = elapsedTime % sliderProgressAmount;
                fillBar.value += sliderProgressAmount;
            }
        }
    }

}