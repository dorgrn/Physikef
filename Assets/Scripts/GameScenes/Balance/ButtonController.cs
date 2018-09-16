using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GameScenes.Balance
{
    public class ButtonController : MonoBehaviour
    {
        private readonly Dictionary<string, Vector3> answerAndLocationMap = new Dictionary<string, Vector3>();

        private bool gazedAt = false;
        private float progressBits;
        private float elapsedTime = 0f;
        private Slider fillBar;
        private const float millsecsToFill = 200f;
        private string value;
        private SceneController m_sceneController;

        private void Awake()
        {
            Text label = GetComponentInChildren<Text>();
            value = label.text;
            m_sceneController = FindObjectOfType<SceneController>();
        }

        void Start()
        {
            progressBits = millsecsToFill / 1000f;
            fillBar = GetComponent<Slider>();

            answerAndLocationMap.Add("1", new Vector3(-7, 1.8f, 0));
            answerAndLocationMap.Add("2", new Vector3(-4.5f, 1.8f, 0));
            answerAndLocationMap.Add("3", new Vector3(-2, 1.8f, 0));

        }

        public void SetGazedAt(bool gazedAt)
        {
            Debug.Log(string.Format("{0} Gazed at to {1}", this, gazedAt));
            this.gazedAt = gazedAt;
        }

        private void DoAction()
        {
            if (fillBar.value < 1f)
            {
                return;
            }
            Vector3 weightPoistion = new Vector3(0,0,0) ;
            answerAndLocationMap.TryGetValue(value, out weightPoistion);
            SceneController.GetLeftWeight().transform.position = weightPoistion;
            SceneController.GetLeftWeight().SetActive(true);
            Physics.gravity = new Vector3(0, -9.81f, 0);

            m_sceneController.SubmitAnswer(value);
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

