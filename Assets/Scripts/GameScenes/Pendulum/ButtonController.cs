using UnityEngine;
using UnityEngine.UI;

namespace GameScenes.Pendulum
{
    public class ButtonController : MonoBehaviour
    {
        private bool m_gazedAt = false;
        private float m_progressBits;
        private float m_elapsedTime = 0f;
        private Slider m_fillBar;
        private const float millsecsToFill = 200f;
        private SceneController m_sceneController;

        private void Awake()
        {
            m_sceneController = FindObjectOfType<SceneController>();
        }

        void Start()
        {
            m_progressBits = millsecsToFill / 1000f;
            m_fillBar = GetComponent<Slider>();
        }

        public void SetGazedAt(bool gazedAt)
        {
            Debug.Log(string.Format("{0} Gazed at to {1}", this, gazedAt));
            m_gazedAt = gazedAt;
        }

        private void DoAction()
        {
            if (m_fillBar.value < 1f)
            {
                return;
            }

            Text label = GetComponentInChildren<Text>();
            m_sceneController.SubmitAnswer(label.text);
        }

        void FixedUpdate()
        {
            if (m_fillBar.value >= 1f)
            {
                DoAction();
            }

            if (!m_gazedAt)
            {
                m_fillBar.value = 0f;
                return;
            }

            m_elapsedTime += Time.deltaTime;
            if (m_elapsedTime >= m_progressBits && m_fillBar.value < 1f)
            {
                m_elapsedTime = m_elapsedTime % m_progressBits;
                m_fillBar.value += m_progressBits;
            }
        }
    }
}