using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class LoggedInOptionsScreenUser : AbstractScreenOptionsUser
    {
        [SerializeField] private GameObject m_ExDropdownHolder;
        private Dropdown m_ExDropdown;
        [SerializeField] private GameObject m_HwDropdownHolder;
        private Dropdown m_HwDropdown;
        [SerializeField] private Text m_SceneForHwLabel;

        public override async void InitUser()
        {
            m_UsernameText = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            m_ScreenTitle = "Choose homework";
            m_ExDropdown = initDropdown(m_ExDropdownHolder);
            m_HwDropdown = initDropdown(m_HwDropdownHolder);

            m_HwDropdown.onValueChanged.AddListener(async delegate { await UpdateDropdown(); });
            await UpdateDropdown();
        }

        private async Task<string> getSceneNameByHomework()
        {
            return (await ServicesManager.GetDataAccessLayer().GetHomeworkByNameAsync(m_HwDropdown.captionText.text))
                .SceneName;
        }

        Dropdown initDropdown(GameObject dropdownHolder)
        {
            dropdownHolder.SetActive(true);
            return createDropDown(dropdownHolder);
        }

        public override Task<string> GetChosenExercise()
        {
            return Task.FromResult(m_ExDropdown.captionText.text);
        }

        public override string GetChosenScene()
        {
            return m_SceneForHwLabel.text;
        }

        private async Task populateHwDropdownAsync()
        {
            IEnumerable<HomeWork> homework =
                (await ServicesManager.GetDataAccessLayer().GetHomeworkByUserEmailAsync(m_UsernameText)).ToList();

            if (homework.Any())
            {
                m_HwDropdown.options = homework.Select(hw => new Dropdown.OptionData(hw.Name)).ToList();
            }
        }

        private async Task populateExDropdownByHwAsync()
        {
            string hwName = m_HwDropdown.captionText.text;
            string sceneForHw = (await ServicesManager.GetDataAccessLayer().GetHomeworkByNameAsync(hwName)).SceneName;

            IEnumerable<Exercise> exercisesForScene =
                (await ServicesManager.GetDataAccessLayer().GetExercisesAsync(sceneForHw)).ToList();

            if (exercisesForScene.Any())
            {
                m_ExDropdown.options =
                    exercisesForScene.Select(ex => new Dropdown.OptionData(ex.ExerciseName)).ToList();
            }
        }

        public override async Task UpdateDropdown()
        {
            await populateHwDropdownAsync();
            await populateExDropdownByHwAsync();
            m_SceneForHwLabel.text =
                await getSceneNameByHomework();
        }
    }
}