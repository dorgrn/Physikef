using System;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class LoginForm : Form
    {
        private readonly IAuthenticationManager m_AuthManager;
        private readonly IDataAccessLayer m_Dal;
        public LoginForm()
        {
            InitializeComponent();
            m_AuthManager = ServicesManager.GetAuthManager();
            m_Dal = ServicesManager.GetDataAccessLayer();
        }

        private async void LoginButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                LoginResult result = await m_AuthManager.LoginAsync(EmailTextBox.Text, PasswordTextBox.Text);

                if (result.LoggedInUser.usertype == "Teacher")
                {
                    new TeacherOptionsForm(m_Dal, result.LoggedInUser).Show();
                }
                else
                {
                    var hwForm = new ShowHomeworkForm(m_Dal, result.LoggedInUser);
                    await hwForm.InitializeAsync();
                    hwForm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid login parameters");
            }
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            new RegisterForm(m_AuthManager).Show();
        }
    }
}