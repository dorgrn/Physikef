using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class TeachersOptionsController : MonoBehaviour
    {
        [SerializeField] private Text m_UsernameLabel;
        [SerializeField] private Text m_MessagesText;

        async void Start()
        {
            await InitLabels();
        }

        private async Task InitLabels()
        {
            m_MessagesText.text = string.Empty;
            string userEmail = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            if (userEmail != null)
            {
                User user = await ServicesManager.GetDataAccessLayer().GetUserByEmailAsync(userEmail);
                m_UsernameLabel.text = user == null ? string.Empty : user.displayname;
            }
        }
    }
}