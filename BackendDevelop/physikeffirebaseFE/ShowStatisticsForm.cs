using System;
using System.Windows.Forms;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class ShowStatisticsForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        public ShowStatisticsForm(IDataAccessLayer dal)
        {
            m_DAL = dal;
            InitializeComponent();
        }

        private async void ShowStudentStatisticsButton_Click(object sender, EventArgs e)
        {
            var studentStatistics = await m_DAL.GetStudentStatisticsAsync(StudentIDTextBox.Text);
            StatisticslistView.View = View.List;

            foreach (var result in studentStatistics)
            {
                StatisticslistView.Items.Add(result.ToString());
            }
        }
    }
}
