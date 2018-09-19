using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class StudentScreenController : MonoBehaviour
{
    private void Start()
    {
    }

    public void StartButton_OnClick()
    {
        SwapToVR();
        SceneManager.LoadScene("SceneSelectionMenu");
    }

    public static void SwapToVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        XRSettings.enabled = true;
    }

    public static void SwapFromVR()
    {
        XRSettings.LoadDeviceByName("None");
        XRSettings.enabled = false;
    }
}