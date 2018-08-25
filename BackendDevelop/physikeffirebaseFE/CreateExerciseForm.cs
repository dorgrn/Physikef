using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PhysikeffirebaseBE.Interfaces;

namespace physikeffirebaseFE
{
    public partial class CreateExerciseForm : Form
    {
        private readonly IDataAccessLayer m_DAL;
        public CreateExerciseForm(IDataAccessLayer dal)
        {
            m_DAL = dal;
            InitializeComponent();
        }

        private async void SubmitExerciseButton_Click(object sender, EventArgs e)
        {
            if (!isAllParametersEntered())
            {
                MessageBox.Show("At least one of the parameters is missing");
                return;
            }

            int index;
            if (Int32.TryParse(correctAnswerIndexTextBox.Text, out index) == false || index > 4 || index < 1)
            {
                MessageBox.Show("correct answer index must be a number between 1 and 4");
                return;
            }

            List<string> answers = new List<string>()
            {
                Answer1TextBox.Text,
                Answer2TextBox.Text,
                Answer3TextBox.Text,
                Answer4TextBox.Text
            };

            await m_DAL.AddExerciseAsync(SceneNameTextBox.Text, QuestionTextBox.Text, answers, index - 1);
            MessageBox.Show("Exercise was added");
            Close();
        }

        private bool isAllParametersEntered()
        {
            return !string.IsNullOrEmpty(SceneNameTextBox.Text) &&
                   !string.IsNullOrEmpty(Answer1TextBox.Text) &&
                   !string.IsNullOrEmpty(Answer2TextBox.Text) &&
                   !string.IsNullOrEmpty(Answer3TextBox.Text) &&
                   !string.IsNullOrEmpty(Answer4TextBox.Text) &&
                   !string.IsNullOrEmpty(QuestionTextBox.Text) &&
                   !string.IsNullOrEmpty(correctAnswerIndexTextBox.Text);
        }
    }
}
