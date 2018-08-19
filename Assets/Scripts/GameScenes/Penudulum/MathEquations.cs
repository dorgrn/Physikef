using UnityEngine;

namespace GameScenes.Penudulum
{
    public class MathEquations : MonoBehaviour
    {
        // Period of time, in seconds, in which a simple pendulum completes a cycle.
        public float GetOscillationPeriod(Vector3 gravity, float ropeLength)
        {
            return 2 * Mathf.PI * Mathf.Sqrt(ropeLength / Physics.gravity.y);
        }
    }
}