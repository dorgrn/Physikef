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
            float bobDistanceCoveredMeters = Mathf.PI * m_PendulumScript.ropeLength; // pi * radius = half a circle
            float oscillationPeriod = m_PendulumColliderDetector.GetAvgOscillationPeriodInMillisec() / 1000;
            float bobVelocity = oscillationPeriod == 0 ? 0 : bobDistanceCoveredMeters / oscillationPeriod;

            // TODO: figure out how to get bob's velocity
            m_InfoText.text = string.Format(
                "Oscillation period(avg.):{0:0.00}s\n\nRope length:{1}m\n\nBob velocity:{2:0.00}m/s\n\nGravity:{3}m/s^2",
                oscillationPeriod,
                m_PendulumScript.ropeLength,
                bobVelocity,
                Physics.gravity.magnitude
            );
        }
    }
}