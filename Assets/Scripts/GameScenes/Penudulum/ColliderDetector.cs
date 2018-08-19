using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace GameScenes.Penudulum
{
    public class ColliderDetector : MonoBehaviour
    {
        private Stopwatch collisionTimer;
        private int collisionNumber = 0;

        private void Start()
        {
            collisionTimer = Stopwatch.StartNew();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bob"))
            {
                collisionNumber++;
                Debug.Log("Hit number:" + collisionNumber);

                if (collisionNumber % 2 == 0) // is oscillation of bob
                {
                    Debug.Log("timer is: " + collisionTimer.ElapsedMilliseconds);
                    collisionTimer = Stopwatch.StartNew();
                }
            }
            else
            {
                Debug.Log("problem!");
            }
        }
    }
}