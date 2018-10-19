using Physikef.Controller;
using UnityEngine;

namespace Physikef.GameScenes.RampAndPulley
{
    public class RampPulleyInfoController : InfoTextController
    {


        [SerializeField] private GameObject m_BoxOnRamp;
        [SerializeField] private GameObject m_BoxInAir;

        void Update()
        {
            string text =
                $@"Ramp incline:30 deg
Box on ramp velocity:{m_BoxOnRamp.GetComponent<Rigidbody>().velocity.magnitude.ToString("0.00")}
Box in air velocity:{m_BoxInAir.GetComponent<Rigidbody>().velocity.magnitude.ToString("0.00")}";
            UpdateInfoText(text);
        }
    }
}