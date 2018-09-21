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
        [SerializeField] private Dropdown m_HwDropdown;
        [SerializeField] private Text m_UsernameText;
        private User m_CurrentUser;

        async void Start()
        {
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            m_CurrentUser = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(userEmail);

            if (m_CurrentUser == null)
            {
                throw new Exception("User not defined!");
            }

            m_UsernameText.text = m_CurrentUser.displayname;
            await populateHwDropdownAsync();
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
            SwitchToScene.SwapToVR();
            SceneManager.LoadScene("SceneSelectionMenu");
        }
    }
}