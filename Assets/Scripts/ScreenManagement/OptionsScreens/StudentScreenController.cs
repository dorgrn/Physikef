using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class StudentScreenController : MonoBehaviour
    {
        [SerializeField] private GameObject m_ExerciseCanvas;
        [SerializeField] private GameObject m_SplashCanvas;
        [SerializeField] private Text m_UsernameText;
        [SerializeField] private Text m_Title;
        private AbstractScreenOptionsUser m_ScreenOptionsUser;
        private const float SPLASH_SCREEN_SECONDS = 2;


        async void Start()
        {
            var user = await GetUserFromDBAsync();

            if (user == null)
            {
                m_ScreenOptionsUser = gameObject.GetComponent<AnonymousScreenOptionsUser>();
            }
            else
            {
                m_ScreenOptionsUser = gameObject.GetComponent<LoggedInOptionsScreenUser>();
            }

            m_ScreenOptionsUser.InitUser();
            m_UsernameText.text = m_ScreenOptionsUser.UsernameText;
            m_Title.text = m_ScreenOptionsUser.ScreenTitle;
        }

        private static async Task<User> GetUserFromDBAsync()
        {
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            return await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(userEmail);
        }


        public async void StartButton_OnClick()
        {
            if (string.IsNullOrEmpty(m_ScreenOptionsUser.GetChosenScene()))
            {
                ScreenManagementGeneral.LogError("No scene found to start");
                throw new Exception("No scene found");
            }

            string chosenExercise = await m_ScreenOptionsUser.GetChosenExercise();
            string chosenScene = m_ScreenOptionsUser.GetChosenScene();

            Debug.LogFormat("Scene:{0} Ex:{1}", chosenScene, chosenExercise);

            PlayerPrefs.SetString("chosenExercise", chosenExercise);

            StartCoroutine(showSplashAndMoveToScene(chosenScene));
        }

        private IEnumerator showSplashAndMoveToScene(string chosenScene)
        {
            m_ExerciseCanvas.SetActive(false);
            m_SplashCanvas.SetActive(true);
            yield return new WaitForSeconds(SPLASH_SCREEN_SECONDS);
            SceneManager.LoadScene(chosenScene);
        }
    }
}