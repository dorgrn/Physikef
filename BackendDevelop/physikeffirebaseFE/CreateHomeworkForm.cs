using System;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class CreateHomeworkForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        private readonly User m_LoggedInUser;
        public CreateHomeworkForm(IDataAccessLayer dal, User loggedInUser)
        {
            InitializeComponent();

            m_DAL = dal;
            m_LoggedInUser = loggedInUser;
        }

        private void CreateHomeWorkButton_Click(object sender, EventArgs e)
        {
            var students = studentsTextBox.Text.Split('\n');
            m_DAL.AddHomeworkAsync(m_LoggedInUser.displayname ,HomeWorkNameTextBox.Text, SceneNameTextBox.Text, students);
        }
    }
}
