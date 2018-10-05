using UnityEngine;

namespace Physikef.GameScenes.DirectionPointer
{
    public class DirectionPointer : MonoBehaviour
    {
        [SerializeField] private GameObject m_Target;
        private readonly float m_Speed = 10f;

        void FixedUpdate()
        {
            if (m_Target != null)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(m_Target.transform.position),
                    m_Speed * Time.deltaTime);
            }
        }

        public void SetTarget(GameObject target)
        {
            m_Target = target;
        }
    }
}