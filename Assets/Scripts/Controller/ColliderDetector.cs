using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GameScenes.Pendulum
{
    public class ColliderDetector : MonoBehaviour
    {
        private Stopwatch m_collisionTimer;
        private int m_collisionNumber = 0;
        private float m_sumOscillationPeriod = 0f;

        private void Start()
        {
            m_collisionTimer = Stopwatch.StartNew();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bob"))
            {
                m_collisionNumber++;
                Debug.Log("Hit number:"
                          + m_collisionNumber);

                if (m_collisionNumber % 2 == 0) // is oscillation of bob
                {
                    Debug.Log("timer is: " + m_collisionTimer.ElapsedMilliseconds);
                    m_sumOscillationPeriod += m_collisionTimer.ElapsedMilliseconds;
                    m_collisionTimer = Stopwatch.StartNew();
                }
            }
            else
            {
                Debug.Log("problem!");
            }
        }

        public float GetAvgOscillationPeriodInMillisec()
        {
            return m_collisionNumber == 0 ? 0 : m_sumOscillationPeriod / m_collisionNumber;
        }
    }
}