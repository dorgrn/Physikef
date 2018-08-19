using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class ShowHomeworkForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        private readonly User m_LoggedInUser;

        public ShowHomeworkForm(IDataAccessLayer dal, User LoggedInUser)
        {
            InitializeComponent();

            m_DAL = dal;
            m_LoggedInUser = LoggedInUser;
            
        }

        public async Task InitializeAsync()
        {
            IEnumerable<HomeWork> homework = await m_DAL.GetHomeWorkAsync(m_LoggedInUser.userid);
            HomeworkListBox.DataSource = homework.Select(hw => hw.Name).ToList();
        }

        private async void SelectHomeworkButton_Click(object sender, System.EventArgs e)
        {
            string selectedItem = HomeworkListBox.SelectedItem.ToString();
            var homeworks = await m_DAL.GetHomeWorkAsync(m_LoggedInUser.userid);
            var scene = homeworks.Where(hw => hw.Name == selectedItem).Select(hw => hw.SceneName).First();
            var exercises = await m_DAL.GetExercisesAsync(scene);

            foreach (var exercise in exercises)
            {
                new ExerciseForm(exercise, m_LoggedInUser, m_DAL).Show();
            }
        }
    }
}
