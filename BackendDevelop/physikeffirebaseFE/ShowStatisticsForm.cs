using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class ShowStatisticsForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        private readonly StatisticsSummaryGenerator m_StatisticsSummaryGenerator;
        public ShowStatisticsForm(IDataAccessLayer dal, StatisticsSummaryGenerator statisticsSummaryGenerator)
        {
            m_DAL = dal;
            m_StatisticsSummaryGenerator = statisticsSummaryGenerator;
            InitializeComponent();
        }

        private async void ShowStudentStatisticsButton_Click(object sender, EventArgs e)
        {
            var studentStatistics = await m_DAL.GetStudentStatisticsAsync(StudentIDTextBox.Text);

            SummaryLabel.Text = "Summary: " + m_StatisticsSummaryGenerator.GenerateStatisticsCorrectAnswersSummary(studentStatistics);
            StatisticslistView.View = View.List;

            foreach (var result in studentStatistics)
            {
                StatisticslistView.Items.Add(result.ToString());
            }
        }
    }
}
