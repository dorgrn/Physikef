using System.Collections;
using UnityEngine;

namespace GameScenes.BallOnRamp
{
    public class RingController : MonoBehaviour
    {
        private GameObject target;
        [SerializeField] new GameObject particleSystem;


        void Start()
        {
            target = SceneController.GetTarget();
            particleSystem.SetActive(false);
        }

        private void Update()
        {
            if (particleSystem.activeInHierarchy)
                return;

            if (transform.position.x - target.transform.position.x <= 0)
            {
                StartCoroutine(setActiveAfterSeconds(1));
            }
        }

        IEnumerator setActiveAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            particleSystem.SetActive(true);
        }
    }
}