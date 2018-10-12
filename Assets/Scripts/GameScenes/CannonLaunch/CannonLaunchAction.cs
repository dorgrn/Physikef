using System.Collections;
using UnityEngine;

namespace Physikef.GameScenes.CannonLaunch
{
    public class CannonLaunchAction : MonoBehaviour
    {
        public GameObject Cannon;
        public GameObject CannonBall;
        public GameObject HingePoint;
        public LineRenderer Line;

        public Vector3 ballStartingPosition;
        private float angle = 45;


        void Start()
        {
            this.ballStartingPosition = CannonBall.transform.position;
            StartCoroutine(rotateAndShoot(this.angle));
        }

        IEnumerator rotateAndShoot(float deg)
        {
            Cannon.transform.RotateAround(HingePoint.transform.position, Vector3.forward, 1);
            yield return new WaitForSeconds(0.1f);
            deg--;
            if (deg > 0)
                StartCoroutine(rotateAndShoot(deg));
            else
            {
                this.ballStartingPosition = CannonBall.transform.position;
                CannonBall.GetComponent<Rigidbody>().useGravity = true;
                CannonBall.GetComponent<Rigidbody>().AddForce(CannonBall.transform.up.normalized * 400);
            }
        }

        public float GetCannonBallVelocity()
        {
            return CannonBall.GetComponent<Rigidbody>().velocity.magnitude;
        }

        public float GetCanonBallDistanceFromCannon()
        {
            return Vector3.Distance(ballStartingPosition, CannonBall.transform.position);
        }

        public float GetCannonRotationDegree()
        {
            return Cannon.transform.rotation.eulerAngles.y;
        }
    }
}