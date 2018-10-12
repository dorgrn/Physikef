using Controllers;
using UnityEngine;

namespace Physikef.GameScenes.CannonLaunch
{
    public class CannonLaunchInfoTextController : InfoTextController
    {
        [SerializeField] private CannonLaunchAction m_CannonLaunchScript;

        private void FixedUpdate()
        {
            // TODO: figure out how to get ball's velocity

            string text =
                $@"Cannon ball velocity:{m_CannonLaunchScript.GetCannonBallVelocity()}
Gravity:{Physics.gravity.magnitude}
Distance:{m_CannonLaunchScript.GetCanonBallDistanceFromCannon()}
Cannon degree:{m_CannonLaunchScript.GetCannonRotationDegree()}";
            UpdateInfoText(text);
        }
    }
}