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
        [SerializeField] private GameObject m_ExDropDownHolder;
        [SerializeField] private Text m_UsernameText;
        [SerializeField] private Text m_Title;
        [SerializeField] private Text m_SceneForHw;
        private Dropdown m_HwDropdown;
        private Dropdown m_ExDropdown;
        private User m_CurrentUser;
        private const string CHOSEN_HOMEWORK = "chosenHomework";
        private const float SPLASH_SCREEN_SECONDS = 2;


        async void Start()
        {
            m_HwDropdown = createDropDown(m_HWDropDownHolder);
            m_ExDropdown = createDropDown(m_ExDropDownHolder);
            m_HwDropdown.onValueChanged.AddListener(async delegate
            {
                string hwDropdownOption = m_HwDropdown.options[m_HwDropdown.value].text;
                await updateSceneForHW(hwDropdownOption);
            });


            await init();
        }

        private async Task updateSceneForHW(string homeworkName)
        {
            string sceneName = (await ServicesManager.GetDataAccessLayer().GetHomeworkByNameAsync(homeworkName))
                .SceneName;
            m_SceneForHw.text = $"Exercise for chosen homework: {sceneName}";
        }

        private Dropdown createDropDown(GameObject dropDownHolder)
        {
            Dropdown created = dropDownHolder.GetComponentInChildren<Dropdown>();
            created.options = new List<Dropdown.OptionData>()
            {
                new Dropdown.OptionData("Empty")
            };

            return created;
        }

        async Task init()
        {
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();

            // user is anonymous
            if (string.IsNullOrEmpty(userEmail))
            {
                await initAnonymousUserAsync();
            }
            else
            {
                await initLoggedInUserAsync(userEmail);
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

            m_UsernameText.text = m_CurrentUser.displayname;
            m_ExDropDownHolder.SetActive(false);
            await populateHwDropdownAsync();
        }

        private async Task initAnonymousUserAsync()
        {
            m_UsernameText.text = "Anonymous";
            m_Title.text = "Choose exercise";
            m_HWDropDownHolder.SetActive(false);
            await PopulateExDropdownAsync();
        }

        async Task PopulateExDropdownAsync()
        {
            IEnumerable<Exercise> exercises =
                (await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync()).ToList();
            if (exercises.Any())
            {
                m_ExDropdown.options = exercises.Select(exe => exe.SceneName).Distinct()
                    .Select(sceneName => new Dropdown.OptionData(sceneName)).ToList();
            }
        }

        async Task populateHwDropdownAsync()
        {
            IEnumerable<HomeWork> homework =
                (await ServicesManager.GetDataAccessLayer().GetHomeworkByUserEmailAsync(m_CurrentUser.email)).ToList();
            if (homework.Any())
            {
                m_HwDropdown.options = homework.Select(hw => new Dropdown.OptionData(hw.Name)).ToList();
            }
        }

        bool isUserAnonymous()
        {
            return m_CurrentUser == null;
        }

        public async void StartButton_OnClick()
        {
            string chosenScene;
            if (isUserAnonymous())
            {
                chosenScene = m_ExDropdown.options[m_ExDropdown.value].text;
            }
            else
            {
                IEnumerable<HomeWork> homeWork = (await ServicesManager.GetDataAccessLayer()
                    .GetHomeworkByUserEmailAsync(m_CurrentUser.email)).ToList();
                PlayerPrefs.SetString(CHOSEN_HOMEWORK, homeWork.FirstOrDefault()?.Name);
                chosenScene = homeWork
                    .FirstOrDefault(hw => hw.Name == m_HwDropdown.options[m_HwDropdown.value].text)?.SceneName;
            }

            if (string.IsNullOrEmpty(chosenScene) || chosenScene == "Empty")
            {
                ScreenManagementGeneral.LogError($"Didn't found wanted scene {chosenScene}");
            }

            // static insertion of player's chosen homework 
            if (isUserAnonymous())
            {
                PlayerPrefs.SetString("chosenScene", chosenScene);
            }
            else
            {
                PlayerPrefs.SetString("chosenHomework", chosenScene);
            }

            StartCoroutine(showSplashAndMoveToScene(chosenScene));
        }

        private IEnumerator showSplashAndMoveToScene(string chosenHw)
        {
            m_ExerciseCanvas.SetActive(false);
            m_SplashCanvas.SetActive(true);
            yield return new WaitForSeconds(SPLASH_SCREEN_SECONDS);
            SceneManager.LoadScene(chosenHw);
        }
    }
}