namespace physikeffirebaseFE
{
    partial class ExerciseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.answer1 = new System.Windows.Forms.RadioButton();
            this.AnswersBox = new System.Windows.Forms.GroupBox();
            this.answer2 = new System.Windows.Forms.RadioButton();
            this.answer3 = new System.Windows.Forms.RadioButton();
            this.answer4 = new System.Windows.Forms.RadioButton();
            this.CheckAnswerButton = new System.Windows.Forms.Button();
            this.AnswersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Location = new System.Drawing.Point(13, 25);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(49, 13);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "Question";
            // 
            // answer1
            // 
            this.answer1.AutoSize = true;
            this.answer1.Location = new System.Drawing.Point(18, 19);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(85, 17);
            this.answer1.TabIndex = 1;
            this.answer1.TabStop = true;
            this.answer1.Text = "radioButton1";
            this.answer1.UseVisualStyleBackColor = true;
            // 
            // AnswersBox
            // 
            this.AnswersBox.Controls.Add(this.answer4);
            this.AnswersBox.Controls.Add(this.answer3);
            this.AnswersBox.Controls.Add(this.answer2);
            this.AnswersBox.Controls.Add(this.answer1);
            this.AnswersBox.Location = new System.Drawing.Point(16, 52);
            this.AnswersBox.Name = "AnswersBox";
            this.AnswersBox.Size = new System.Drawing.Size(200, 124);
            this.AnswersBox.TabIndex = 2;
            this.AnswersBox.TabStop = false;
            // 
            // answer2
            // 
            this.answer2.AutoSize = true;
            this.answer2.Location = new System.Drawing.Point(18, 42);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(85, 17);
            this.answer2.TabIndex = 2;
            this.answer2.TabStop = true;
            this.answer2.Text = "radioButton2";
            this.answer2.UseVisualStyleBackColor = true;
            // 
            // answer3
            // 
            this.answer3.AutoSize = true;
            this.answer3.Location = new System.Drawing.Point(18, 65);
            this.answer3.Name = "answer3";
            this.answer3.Size = new System.Drawing.Size(85, 17);
            this.answer3.TabIndex = 3;
            this.answer3.TabStop = true;
            this.answer3.Text = "radioButton3";
            this.answer3.UseVisualStyleBackColor = true;
            // 
            // answer4
            // 
            this.answer4.AutoSize = true;
            this.answer4.Location = new System.Drawing.Point(18, 88);
            this.answer4.Name = "answer4";
            this.answer4.Size = new System.Drawing.Size(85, 17);
            this.answer4.TabIndex = 4;
            this.answer4.TabStop = true;
            this.answer4.Text = "radioButton4";
            this.answer4.UseVisualStyleBackColor = true;
            // 
            // CheckAnswerButton
            // 
            this.CheckAnswerButton.Location = new System.Drawing.Point(72, 205);
            this.CheckAnswerButton.Name = "CheckAnswerButton";
            this.CheckAnswerButton.Size = new System.Drawing.Size(75, 23);
            this.CheckAnswerButton.TabIndex = 3;
            this.CheckAnswerButton.Text = "Check";
            this.CheckAnswerButton.UseVisualStyleBackColor = true;
            this.CheckAnswerButton.Click += new System.EventHandler(this.CheckAnswerButton_Click);
            // 
            // ExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 450);
            this.Controls.Add(this.CheckAnswerButton);
            this.Controls.Add(this.AnswersBox);
            this.Controls.Add(this.QuestionLabel);
            this.Name = "ExerciseForm";
            this.Text = "ExerciseForm";
            this.AnswersBox.ResumeLayout(false);
            this.AnswersBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.RadioButton answer1;
        private System.Windows.Forms.GroupBox AnswersBox;
        private System.Windows.Forms.RadioButton answer4;
        private System.Windows.Forms.RadioButton answer3;
        private System.Windows.Forms.RadioButton answer2;
        private System.Windows.Forms.Button CheckAnswerButton;
    }
}