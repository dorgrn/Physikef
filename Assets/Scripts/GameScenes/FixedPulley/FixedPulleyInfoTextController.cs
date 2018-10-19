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
                $"Box height:{leftObject.transform.position.y:0.00}\nLantern height:{rightObject.transform.position.y:0.00}\nGravity:{Physics.gravity.normalized.magnitude:0.00}";
            UpdateInfoText(text);
        }
    }
}