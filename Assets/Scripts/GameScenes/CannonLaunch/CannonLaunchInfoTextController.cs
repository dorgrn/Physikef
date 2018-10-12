using Controllers;
using UnityEngine;

namespace GameScenes.CannonLaunch
{
    public class CannonLaunchInfoTextController : InfoTextController
    {
        [SerializeField] private Physikef.GameScenes.CannonLaunch.CannonLaunch m_CannonLaunchScript;
        [SerializeField] private GameObject m_CannonBall;

        private void FixedUpdate()
        {
            // TODO: figure out how to get ball's velocity

            string text = string.Format("Cannon ball velocity:{0}\nGravity:{1}\nDistance:{2}",
                0, Physics.gravity.magnitude, 0
              );
            UpdateInfoText(text);
        }
    }
}