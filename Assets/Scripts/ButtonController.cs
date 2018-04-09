using UnityEngine;
using UnityEngine.UI;
namespace Physikef
{
    public class ButtonController : MonoBehaviour
    {
        private bool gazedAt = false;
        Slider fillBar;
        [SerializeField] float millsecsToFill = 200f;
        private float elapsedTime = 0f;
        private float progressBits;

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
            Debug.Log(string.Format("{0} Doing action", this));
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