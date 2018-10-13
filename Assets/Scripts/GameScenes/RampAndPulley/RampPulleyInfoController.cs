using Controllers;
using Physikef.Controller;
using UnityEngine;

namespace Physikef.GameScenes.BallOnRamp
{
    public class RampPulleyInfoController : InfoTextController
    {


        [SerializeField] private GameObject m_BoxOnRamp;
        [SerializeField] private GameObject m_BoxInAir;

        void Update()
        {
            string text =
                $@"Ramp incline:30 deg
Box on ramp velocity:{m_BoxOnRamp.GetComponent<Rigidbody>().velocity.magnitude}
Box in air velocity:{m_BoxInAir.GetComponent<Rigidbody>().velocity.magnitude}";
            UpdateInfoText(text);
        }
    }
}