using Controllers;
using Physikef.Controller;
using UnityEngine;

namespace Physikef.GameScenes.Pendulum
{
    public class PendulumInfoTextController : InfoTextController
    {
        [SerializeField] private ColliderDetector m_PendulumColliderDetector;
        [SerializeField] private Pendulum m_PendulumScript;
        [SerializeField] private GameObject m_Bob;

        private void FixedUpdate()
        {
            // TODO: figure out how to get bob's velocity

            string text = string.Format("Rope length:{0}\nGravity:{1}\nOscillation period(avg.):{2:0.00}",
                m_PendulumScript.ropeLength, Physics.gravity.magnitude,
                m_PendulumColliderDetector.GetAvgOscillationPeriodInMillisec() / 1000);
            UpdateInfoText(text);
        }
    }
}