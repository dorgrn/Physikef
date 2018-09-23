using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModestTree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.TeachersOptionsScreen
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
            m_HwDropdown = m_HWDropDownHolder.GetComponentInChildren<Dropdown>();
            m_ExDropdown = m_ExDropDownHolder.GetComponentInChildren<Dropdown>();
            await init();
        }

        async Task init()
        {
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();

            // user is anonymous
            if (userEmail.IsEmpty())
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
            await populateExDropdwonAsync();
        }

        async Task populateExDropdwonAsync()
        {
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            if (!exercises.IsEmpty())
            {
                m_ExDropdown.options = exercises.Select(exe => new Dropdown.OptionData(exe.SceneName)).ToList();
            }
        }

        async Task populateHwDropdownAsync()
        {
            IEnumerable<HomeWork> homework =
                await ServicesManager.GetDataAccessLayer().GetHomeWorkAsync(m_CurrentUser.userid);
            if (!homework.IsEmpty())
            {
                m_HwDropdown.options = homework.Select(hw => new Dropdown.OptionData(hw.Name)).ToList();
            }
        }

        public void StartButton_OnClick()
        {
            string[] scenes = {"BallOnRamp", "CannonLaunch", "Pendulum"};
            SwitchToScene.SwapToVR();
            string chosenOption = m_HwDropdown.isActiveAndEnabled
                ? m_HwDropdown.options[m_HwDropdown.value].text
                : m_ExDropdown.options[m_ExDropdown.value].text;
            if (scenes.Contains(chosenOption))
            {
                SceneManager.LoadScene(chosenOption);
            }
            else
            {
                throw new Exception($"non implemented scene chosen {chosenOption}");
            }
        }
    }
}