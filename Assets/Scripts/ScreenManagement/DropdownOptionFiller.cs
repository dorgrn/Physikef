using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenManagement
{
    public class DropdownOptionFiller : MonoBehaviour
    {
        private Dropdown m_Dropdown;

        async void Start()
        {
            m_Dropdown = GetComponent<Dropdown>();
            await initDropdown();
        }

        async Task initDropdown()
        {
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            m_Dropdown.options = exercises.Select(exe => new Dropdown.OptionData(exe.SceneName)).ToList();
        }
    }
}