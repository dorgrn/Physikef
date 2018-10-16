using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private GameObject m_HWDropDownHolder;
        [SerializeField] private GameObject m_SceneDropDownHolder;
        [SerializeField] private Text m_UsernameText;
        [SerializeField] private Text m_Title;
        [SerializeField] private Text m_SceneForHw;
        private Dropdown m_HwDropdown;
        private Dropdown m_SceneDropdown;
        private User m_CurrentUser;
        private const float SPLASH_SCREEN_SECONDS = 2;
        private string m_ChosenScene = string.Empty;


        async void Start()
        {
            m_HwDropdown = createDropDown(m_HWDropDownHolder);
            m_SceneDropdown = createDropDown(m_SceneDropDownHolder);
            m_HwDropdown.onValueChanged.AddListener(async delegate { await UpdateHwDropdownAsync(); });
            await init();
        }

        public async Task UpdateHwDropdownAsync()
        {
            string hw = m_HwDropdown.options[m_HwDropdown.value].text;
            await updateExDropdownForHW(hw);
        }

        private async Task updateExDropdownForHW(string homeworkName)
        {
            m_ChosenScene = (await ServicesManager.GetDataAccessLayer().GetHomeworkByNameAsync(homeworkName))
                .SceneName;
            m_SceneForHw.text = $"Scene for chosen homework: {m_ChosenScene}";
        }

        private Dropdown createDropDown(GameObject dropDownHolder)
        {
            return dropDownHolder.GetComponentInChildren<Dropdown>();
        }

        async Task init()
        {
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();

//             user is anonymous
            if (string.IsNullOrEmpty(userEmail))
            {
                await initAnonymousUserAsync();
            }
            else
            {
                await initLoggedInUserAsync(userEmail);
            }
        }

        private async void Update()
        {
            if (string.IsNullOrEmpty(m_SceneForHw.text))
            {
                await UpdateHwDropdownAsync();
            }
        }

        private async Task initLoggedInUserAsync(string userEmail)
        {
            m_CurrentUser = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(userEmail);

            m_Title.text = "Choose homework";

            if (m_CurrentUser == null)
            {
                ScreenManagementGeneral.LogError($"User not defined {userEmail}");
            }

            m_UsernameText.text = m_CurrentUser?.displayname;
            m_SceneDropDownHolder.SetActive(false);
            await PopulateHwDropdownAsync();
        }

        private async Task initAnonymousUserAsync()
        {
            m_UsernameText.text = "Anonymous";
            m_Title.text = "Choose scene";
            m_HWDropDownHolder.SetActive(false);
            await PopulateSceneDropdownAsync();
        }

        async Task PopulateSceneDropdownAsync()
        {
            m_ChosenScene = m_SceneDropdown.options[m_SceneDropdown.value].text;

            IEnumerable<string> scenes =
                (await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync()).Select(ex => ex.SceneName).ToList();

            if (scenes.Any())
            {
                m_SceneDropdown.options = scenes.Select(sc => new Dropdown.OptionData(sc)).Distinct()
                    .ToList();
            }
        }

        async Task PopulateHwDropdownAsync()
        {
            IEnumerable<HomeWork> homework =
                (await ServicesManager.GetDataAccessLayer().GetHomeworkByUserEmailAsync(m_CurrentUser.email)).ToList();
            if (homework.Any())
            {
                m_HwDropdown.options = homework.Select(hw => new Dropdown.OptionData(hw.Name)).ToList();
            }
        }

        public void StartButton_OnClick()
        {
            string sceneInDropdown = m_SceneDropdown.options[m_SceneDropdown.value].text;
            string chosenExercise = sceneInDropdown;

            if (sceneInDropdown != "Empty")
            {
                m_ChosenScene = sceneInDropdown;
            }
            else if (string.IsNullOrEmpty(m_ChosenScene))
            {
                ScreenManagementGeneral.LogError("No scene found to start");
                throw new Exception("No scene found");
            }

            Debug.LogFormat("Scene:{0} Ex:{1}", m_ChosenScene, chosenExercise);

            PlayerPrefs.SetString("chosenExercise", chosenExercise);

            StartCoroutine(showSplashAndMoveToScene());
        }

        private IEnumerator showSplashAndMoveToScene()
        {
            m_ExerciseCanvas.SetActive(false);
            m_SplashCanvas.SetActive(true);
            yield return new WaitForSeconds(SPLASH_SCREEN_SECONDS);
            SceneManager.LoadScene(m_ChosenScene);
        }
    }
}