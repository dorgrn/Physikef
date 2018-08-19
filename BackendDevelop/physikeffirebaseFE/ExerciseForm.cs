using System;
using System.Linq;
using System.Windows.Forms;
using PhysikeffirebaseBE;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class ExerciseForm : Form
    {
        private readonly Exercise m_Exercise;
        private readonly IDataAccessLayer m_DAL;
        private readonly User m_LoggedInUser;
        public ExerciseForm(Exercise exercise, User loggedInUser, IDataAccessLayer DAL)
        {
            m_Exercise = exercise;
            m_LoggedInUser = loggedInUser;
            m_DAL = DAL;
            InitializeComponent();

            var answers = m_Exercise.Answers.ToList();

            QuestionLabel.Text = m_Exercise.Question;
            answer1.Text = answers[0];
            answer2.Text = answers[1];
            answer3.Text = answers[2];
            answer4.Text = answers[3];
        }

        private void CheckAnswerButton_Click(object sender, EventArgs e)
        {
            var selectedAnswer = AnswersBox.Controls.OfType<RadioButton>().First(r => r.Checked).Text;
            bool isCorrect = selectedAnswer == m_Exercise.Answers.ToList()[m_Exercise.CorrectAnswerIndex];
            m_DAL.AddStudentExerciseResultAsync(m_LoggedInUser.userid, m_Exercise.Question, selectedAnswer, isCorrect);

            if (isCorrect)
            {
                MessageBox.Show("Correct");
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
        }
    }
}
