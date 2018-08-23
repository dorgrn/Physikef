using System;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class TeacherOptionsForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        private readonly User m_LoggedInUser;

        public TeacherOptionsForm(IDataAccessLayer dal, User loggedInUser)
        {
            m_DAL = dal;
            m_LoggedInUser = loggedInUser;
            InitializeComponent();
        }

        private void CreateHomeworkButton_Click(object sender, EventArgs e)
        {
            new CreateHomeworkForm(m_DAL, m_LoggedInUser).Show();
        }

        private void GetStatisticsButton_Click(object sender, EventArgs e)
        {
            new ShowStatisticsForm(m_DAL, new StatisticsSummaryGenerator()).Show();
        }

        private void CreateExerciseButton_Click(object sender, EventArgs e)
        {
            new CreateExerciseForm(m_DAL).Show();
        }
    }
}
