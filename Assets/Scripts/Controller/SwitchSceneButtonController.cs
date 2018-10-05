using UnityEngine.SceneManagement;

namespace Physikef.Controller
{
    public class SwitchSceneButtonController : AbstractButtonAction
    {
        public string m_SceneName;

        protected override void DoAction()
        {
            SwitchToScene.SwapFromVR();
            SceneManager.LoadScene(m_SceneName);
        }
    }
}