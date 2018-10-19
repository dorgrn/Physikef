using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class SceneDropdownFiller : AbstractDropdownOptionFiller
    {
        public Dropdown m_ExerciseDropdown; // nullable

        private async void Start()
        {
            ExerciseDropdownFiller exerciseDropdownFiller = null;

            if (m_ExerciseDropdown != null)
            {
                exerciseDropdownFiller = m_ExerciseDropdown.GetComponent<ExerciseDropdownFiller>();
                GetComponent<Dropdown>().onValueChanged.AddListener(
                    async delegate { await exerciseDropdownFiller.UpdateDropdown(); }
                );
            }

            await UpdateDropdown();
            if (exerciseDropdownFiller != null)
            {
                await updateExerciseDropdown(exerciseDropdownFiller);
            }
        }

        // only in cases where m_ExerciseDropdown is present
        private static async Task updateExerciseDropdown(ExerciseDropdownFiller exerciseDropdownFiller)
        {
            await exerciseDropdownFiller.UpdateDropdown();
        }


        public override async Task UpdateDropdown()
        {
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            m_Dropdown.options = exercises.GroupBy(exe => exe.SceneName)
                .Select(group => new Dropdown.OptionData(group.First().SceneName))
                .ToList();
        }
    }
}