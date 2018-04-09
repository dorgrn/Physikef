using UnityEngine;

namespace Physikef
{
    public class GazeController : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnPointerEnter()
        {
            Debug.Log("in gaze");
        }

        public void OnPointerExit()
        {
            Debug.Log("out of gaze");
        }
    }

}
