using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int delayTime = 1;
    [SerializeField] private string sceneName;

    private bool gazedAt = false;
    private float gazeCounter = 0f;

    private void Start()
    {
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
    }


    // based on https://answers.unity.com/questions/1336656/how-to-disable-vr-on-unity-splash-screen-while-goo.html
    public static IEnumerator SwapToVR()
    {
        XRSettings.LoadDeviceByName("Cardboard");
        yield return null;
        XRSettings.enabled = true;
    }

    public static IEnumerator SwapFromVR()
    {
        XRSettings.LoadDeviceByName("None");
        yield return null;
        XRSettings.enabled = false;
    }

    private void Update()
    {
        if (gazedAt && gazeCounter >= delayTime)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (gazedAt)
        {
            gazeCounter += Time.deltaTime;
        }
        else // not gazed at
        {
            gazeCounter = 0f;
        }
    }
}