using UnityEngine;

namespace Physikef.GameScenes.Spring
{
    public class SpringCoil : MonoBehaviour
    {
        public float M_Speed = 2f;
        public Vector3 m_NewScale;
        public Transform m_LeftWall;

        private void Update()
        {
            float delta = M_Speed * Time.deltaTime;
            Vector3 newPos = m_LeftWall.position +
                             new Vector3(0.5f, 0f, 0f);

            transform.localScale = Vector3.Lerp(transform.localScale, m_NewScale, delta);
            transform.position = Vector3.Lerp(transform.position, newPos, delta);
        }
    }
}