using UnityEngine;
namespace Physikef
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] float gravity = 30f;
        [SerializeField] float massMult = 1f;
        [SerializeField] float dragMult;
        [SerializeField] float angularDragMult;

        // Use this for initialization
        void Start()
        {
            //Physics.gravity = new Vector3(0, -gravity, 0);

        }

        // Update is called once per frame
        void Update()
        {

        }

        static public GameObject getTarget()
        {
            return GameObject.FindGameObjectWithTag("Target");
        }

        static public float getTargetDistanceFromRamp()
        {
            GameObject ramp = GameObject.FindGameObjectWithTag("Ramp");
            GameObject target = GameObject.FindGameObjectWithTag("Target");

            if (!ramp || !target)
            {
                return 0;
            }

            return Vector3.Distance(ramp.transform.position, target.transform.position);
        }

    }

}
