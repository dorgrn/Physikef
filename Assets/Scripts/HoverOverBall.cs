using UnityEngine;

namespace Physikef
{
    public class HoverOverBall : MonoBehaviour
    {
        public Transform ball;
        public float hoverDistance = 1.5f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(ball.position.x, ball.position.y + hoverDistance, ball.position.z);

        }
    }
}

