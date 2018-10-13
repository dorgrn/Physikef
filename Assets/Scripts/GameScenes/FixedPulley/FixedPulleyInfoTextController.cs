using Physikef.Controller;
using UnityEngine;

namespace Physikef.GameScenes.FixedPulley
{
    public class FixedPulleyInfoTextController : InfoTextController
    {
        [SerializeField] private GameObject leftObject;
        [SerializeField] private GameObject rightObject;

        void Update()
        {
            string text =
                $"Box height:{leftObject.transform.position.y}\nLantern height:{rightObject.transform.position.y}\nGravity:{Physics.gravity.normalized}";
            UpdateInfoText(text);
        }
    }
}