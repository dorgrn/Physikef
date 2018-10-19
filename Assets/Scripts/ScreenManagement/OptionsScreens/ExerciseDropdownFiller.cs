using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class ExerciseDropdownFiller : AbstractDropdownOptionFiller
    {
        [SerializeField] private Dropdown m_SceneDropdown;

        public override async Task UpdateDropdown()
        {
            string selectedScene = m_SceneDropdown.captionText.text;
            if (selectedScene == "Empty")
            {
                m_Dropdown.interactable = false;
                m_Dropdown.options = new List<Dropdown.OptionData>() {new Dropdown.OptionData("Empty")};
            }

            m_Dropdown.interactable = true;

            IEnumerable<Exercise> exercises =
                await ServicesManager.GetDataAccessLayer().GetExercisesAsync(selectedScene);
            m_Dropdown.options = exercises.Select(exe => new Dropdown.OptionData(exe.ExerciseName)).ToList();
        }
    }
}