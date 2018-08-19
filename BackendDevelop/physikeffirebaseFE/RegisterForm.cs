using System;
using System.Linq;
using System.Windows.Forms;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class RegisterForm : Form
    {
        private readonly IAuthenticationManager m_AuthManager;
        public RegisterForm(IAuthenticationManager AuthManager)
        {
            InitializeComponent();
            m_AuthManager = AuthManager;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (await m_AuthManager.RegisterAsync(EmailTextBox.Text, UserNameTextBox.Text, PasswordTextBox.Text, IDTextBox.Text, UserTypeGroup.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked).Text))
            {
                MessageBox.Show("Registerred");
            }
            else
            {
                MessageBox.Show("could not register");
            }
        }
    }
}
