using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : MonoBehaviour
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