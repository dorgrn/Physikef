using UnityEngine;

namespace GameScenes.Penudulum
{
    public class PendulumSimleImp : MonoBehaviour
    {
        public Transform pivot;
        public float speed = 0.5f;
        private Vector3 v3Pivot; // Pivot in screen space
        private bool dragging = false;
        private float startAngle = 0.0f;
        private float endAngle = -180.0f;
        private float fTimer = 0.0f;
        private float angleDiff;
        private Vector3 v3T = Vector3.zero;
        private float angle;

        void Start()
        {
            v3Pivot = Camera.main.WorldToScreenPoint(pivot.position);
        }

        void Update()
        {
            float f = (Mathf.Sin(fTimer * speed - Mathf.PI / 2.0f) + 1.0f) / 2.0f;

            v3T.Set(0.0f, 0.0f, Mathf.Lerp(startAngle, endAngle, f));
            pivot.eulerAngles = v3T;
            fTimer += Time.deltaTime;
        }
    }
}