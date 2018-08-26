using UnityEngine;
using Vuforia;

namespace GameScenes.Pendulum
{
    public class ForcesArrows : MonoBehaviour
    {
        private GameObject m_target;
        private LineRenderer m_velocityLine;
        private LineRenderer m_accelerationLine;
        private LineDrawer lineDrawer;

        private Vector3 startingPos;
        private Vector3 endPos;
        private Vector3 targetPrevPos;


        void Start()
        {
            m_target = this.gameObject;
            lineDrawer = new LineDrawer();
            startingPos = m_target.transform.position;
            endPos = m_target.transform.position + new Vector3(0f, 2f, 0f);


            //m_velocityLine = m_target.AddComponent<LineRenderer>();
            //m_accelerationLine = m_target.AddComponent<LineRenderer>();

            //m_velocityLine.startColor = m_velocityLine.endColor = Color.blue;
            //m_velocityLine.startWidth = m_velocityLine.endWidth = 5f;
        }

        void FixedUpdate()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
            var direction = transform.position - targetPrevPos;
            var localDirection = transform.InverseTransformDirection(direction);
            var rotation = transform.localRotation;

            lineDrawer.DrawLineInGameView(
                new Vector3(startingPos.x, m_target.transform.position.y, startingPos.z),
                m_target.transform.position, Color.blue);

            lineDrawer.DrawLineInGameView(
                new Vector3(endPos.x, m_target.transform.position.y, endPos.z), m_target.transform.position,
                Color.red);
            targetPrevPos = transform.position;
            //lineDrawer.DrawLineInGameView(m_target.transform.position, Vector3.down, Color.black);
            //m_velocityLine.SetPosition(0, m_target.transform.position);
            //m_velocityLine.SetPosition(1, Vector3.forward);
        }
    }
}