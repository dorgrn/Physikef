using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.TeachersOptionsScreen
{
    public class DropdownOptionFiller : MonoBehaviour
    {
        [SerializeField] private Dropdown m_Dropdown;

        async void Start()
        {
            m_Dropdown = m_Dropdown == null ? GetComponent<Dropdown>() : m_Dropdown;
            m_Dropdown.options = await initDropdown();
        }


        async Task<List<Dropdown.OptionData>> initDropdown()
        {
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            return exercises.Select(exe => new Dropdown.OptionData(exe.SceneName)).ToList();
        }
    }
}