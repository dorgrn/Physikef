using UnityEngine;

namespace GameScenes.BallOnRamp
{
	public class PositionFromRamp : MonoBehaviour
	{
		private GameObject ramp;
		private void Start()
		{
			ramp = SceneController.GetRamp();
			
		}

		
	}
}
