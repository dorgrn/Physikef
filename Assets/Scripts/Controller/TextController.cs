using UnityEngine;
using UnityEngine.UI;

namespace Physikef
{
    public class TextController : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Text forcesText;
        [SerializeField] string targetName = string.Empty;
        private Rigidbody targetRB;
        private int nextUpdate = 1;

        void Start()
        {
            if (target == null)
                target = GameObject.FindWithTag("Target").transform;
            targetRB = target.GetComponent<Rigidbody>();
            if (forcesText == null)
                forcesText = FindObjectOfType<Text>();
            if (targetName.Equals(string.Empty))
                targetName = target.name;
        }

        void Update()
        {
            if (Time.time < nextUpdate)
                return;

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            forcesText.text = string.Format(
                "Velocity: {3}m/s\nMass: {4}kg\nHeight: {0}m\nGravity: {1}G\nFriction: {2}N\n",
                Mathf.FloatToHalf(target.position.y + 1f),
                -1 * Physics.gravity.normalized, targetRB.drag, -1 * targetRB.velocity,
                targetRB.mass);
        }
    }
}