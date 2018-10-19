using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Physikef.GameScenes.Pendulum
{
    public class ColliderDetector : MonoBehaviour
    {
        private Stopwatch m_CollisionTimer;
        private int m_CollisionNumber = 0;
        private float m_SumOscillationPeriod = 0f;
        private bool m_IsDebugMode = false;

        private void Start()
        {
            m_CollisionTimer = Stopwatch.StartNew();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!m_IsDebugMode)
            {
                return;
            }

            if (other.CompareTag("Bob"))
            {
                m_CollisionNumber++;
                Debug.Log("Hit number:"
                          + m_CollisionNumber);

                if (m_CollisionNumber % 2 == 0) // is oscillation of bob
                {
                    Debug.Log("timer is: " + m_CollisionTimer.ElapsedMilliseconds);
                    m_SumOscillationPeriod += m_CollisionTimer.ElapsedMilliseconds;
                    m_CollisionTimer = Stopwatch.StartNew();
                }
            }
            else
            {
                Debug.Log("problem!");
            }
        }

        public float GetAvgOscillationPeriodInMillisec()
        {
            return m_CollisionNumber == 0 ? 0 : m_SumOscillationPeriod / m_CollisionNumber;
        }
    }
}