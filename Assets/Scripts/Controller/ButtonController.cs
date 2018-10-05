using UnityEngine;
using UnityEngine.UI;

namespace Physikef.Controller
{
    // This class is used to do an action of a button in the VR space
    // To use, extend it and override DoAction for desired button onClick  
    public abstract class AbstractButtonAction : MonoBehaviour
    {
        private bool m_GazedAt = false;
        private float m_ProgressBits;
        private float m_ElapsedTime = 0f;
        private Slider m_FillBar;
        private const float m_MillsecsToFill = 200f;
        protected SceneController m_SceneController;

        private void Awake()
        {
            m_SceneController = FindObjectOfType<SceneController>();
        }

        void Start()
        {
            m_ProgressBits = m_MillsecsToFill / 1000f;
            m_FillBar = GetComponent<Slider>();
        }

        public void SetGazedAt(bool gazedAt)
        {
            m_GazedAt = gazedAt;
        }

        protected abstract void DoAction();

        void FixedUpdate()
        {
            if (m_FillBar.value >= 1f)
            {
                DoAction();
            }

            if (!m_GazedAt)
            {
                m_FillBar.value = 0f;
                return;
            }

            m_ElapsedTime += Time.deltaTime;
            if (m_ElapsedTime >= m_ProgressBits && m_FillBar.value < 1f)
            {
                m_ElapsedTime = m_ElapsedTime % m_ProgressBits;
                m_FillBar.value += m_ProgressBits;
            }
        }
    }
}