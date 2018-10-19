using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class AnonymousScreenOptionsUser : AbstractScreenOptionsUser
    {
        [SerializeField] private GameObject m_SceneDropdownHolder;
        private Dropdown m_SceneDropdown;


        public override async void InitUser()
        {
            m_UsernameText = "Anonymous";
            m_ScreenTitle = "Choose scene";
            m_SceneDropdownHolder.SetActive(true);
            m_SceneDropdown = createDropDown(m_SceneDropdownHolder);

            m_SceneDropdown.onValueChanged.AddListener(async delegate { await UpdateDropdown(); });
            await populateSceneDropdownAsync();
        }

        public override async Task<string> GetChosenExercise()
        {
            Exercise ex = (await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync()).FirstOrDefault();
            return ex.ExerciseName;
        }

        public override string GetChosenScene()
        {
            return m_SceneDropdown.captionText.text;
        }

        private async Task populateSceneDropdownAsync()
        {
            m_ChosenScene = m_SceneDropdown.captionText.text;

            IEnumerable<string> scenes =
                (await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync()).Select(ex => ex.SceneName)
                .Distinct().ToList();

            if (scenes.Any())
            {
                m_SceneDropdown.options = scenes.Select(sc => new Dropdown.OptionData(sc))
                    .ToList();
            }
        }

        public override async Task UpdateDropdown()
        {
            await populateSceneDropdownAsync();
        }
    }
}