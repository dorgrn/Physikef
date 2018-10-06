using System;
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
        [SerializeField] private GameObject m_HWDropDownHolder;
        [SerializeField] private GameObject m_ExDropDownHolder;
        [SerializeField] private Text m_UsernameText;
        [SerializeField] private Text m_Title;
        private Dropdown m_HwDropdown;
        private Dropdown m_ExDropdown;
        private User m_CurrentUser;

        async void Start()
        {
            m_HwDropdown = createDropDown(m_HWDropDownHolder);
            m_ExDropdown = createDropDown(m_ExDropDownHolder);

            await init();
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
                throw new Exception("User not defined!");
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
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            if (!exercises.Any())
            {
                m_ExDropdown.options = exercises.Select(exe => new Dropdown.OptionData(exe.SceneName)).ToList();
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
                IEnumerable<HomeWork> homeWork = await ServicesManager.GetDataAccessLayer()
                    .GetHomeworkByUserEmailAsync(m_CurrentUser.email);
                chosenScene = homeWork
                    .FirstOrDefault(hw => hw.Name == m_HwDropdown.options[m_HwDropdown.value].text)?.SceneName;
            }

            if (string.IsNullOrEmpty(chosenScene) || chosenScene == "Empty")
            {
                throw new Exception($"Didn't found wanted scene {chosenScene}");
            }

            SceneManager.LoadScene(chosenScene);
        }
    }
}