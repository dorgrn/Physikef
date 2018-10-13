using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public abstract class AbstractDropdownOptionFiller : MonoBehaviour
    {
        [SerializeField] protected Dropdown m_Dropdown;

        void Start()
        {
            m_Dropdown = m_Dropdown == null ? GetComponent<Dropdown>() : m_Dropdown;
            UpdateDropdown();
        }


        public abstract Task UpdateDropdown();
    }
}