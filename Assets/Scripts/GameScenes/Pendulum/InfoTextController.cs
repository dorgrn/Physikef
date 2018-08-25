using GameScenes.Pendulum;
using TMPro;
using UnityEngine;

namespace GameScenes.Pendulum
{
    public class InfoTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI infoText;
        [SerializeField] private ColliderDetector pendulumColliderDetector;
        [SerializeField] private Pendulum pendulumScript;


        private void FixedUpdate()
        {
            infoText.text = string.Format("Rope length:{0}\nGravity:{1}\nOscillation period(avg.):{2}",
                pendulumScript.ropeLength, Physics.gravity.magnitude,
                pendulumColliderDetector.GetAvgOscillationPeriodInMillisec() / 1000);
        }
    }
}