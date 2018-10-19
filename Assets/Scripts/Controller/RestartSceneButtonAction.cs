using UnityEngine.SceneManagement;

namespace Physikef.Controller
{
    public class RestartSceneButtonAction : AbstractButtonAction
    {
        protected override void DoAction()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine(SceneSwitcher.SwapToVR());
        }
    }
}