using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public abstract class AbstractScreenOptionsUser : MonoBehaviour
    {
        protected string m_UsernameText;
        protected string m_ChosenScene;
        protected string m_ScreenTitle;
        private string usernameText;
        private string screenTitle;


        public string UsernameText => m_UsernameText;

        public string ChosenScene => m_ChosenScene;

        public string ScreenTitle => m_ScreenTitle;

        public abstract Task UpdateDropdown();

        public abstract void InitUser();

        public abstract Task<string> GetChosenExercise();

        protected Dropdown createDropDown(GameObject dropDownHolder)
        {
            return dropDownHolder.GetComponentInChildren<Dropdown>();
        }

        public abstract string GetChosenScene();
    }
}