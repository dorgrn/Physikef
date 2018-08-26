using TMPro;
using UnityEngine;

namespace GameScenes.Pendulum
{
    public class InfoTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_InfoText;
        [SerializeField] private ColliderDetector m_PendulumColliderDetector;
        [SerializeField] private Pendulum m_PendulumScript;
        [SerializeField] private GameObject m_Bob;


        private void FixedUpdate()
        {
            // TODO: figure out how to get bob's velocity
            m_InfoText.text = string.Format("Rope length:{0}\nGravity:{1}\n\nOscillation period(avg.):{2:0.00}",
                m_PendulumScript.ropeLength, Physics.gravity.magnitude,
                m_PendulumColliderDetector.GetAvgOscillationPeriodInMillisec() / 1000);
        }
    }
}