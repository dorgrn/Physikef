using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        public static void Quit()
        {
            Application.Quit();
        }

        public static void SwitchToChooseGame()
        {
            SceneManager.LoadScene("SceneChoose");
        }

        public static void SwitchToSettings()
        {
            SceneManager.LoadScene("Settings");
        }

        public static void SwitchToHighScore()
        {
            SceneManager.LoadScene("HighScore");
        }
    }
}