namespace physikeffirebaseFE
{
    partial class TeacherOptionsForm
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
            this.CreateHomeworkButton = new System.Windows.Forms.Button();
            this.GetStatisticsButton = new System.Windows.Forms.Button();
            this.CreateExerciseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateHomeworkButton
            // 
            this.CreateHomeworkButton.Location = new System.Drawing.Point(61, 140);
            this.CreateHomeworkButton.Name = "CreateHomeworkButton";
            this.CreateHomeworkButton.Size = new System.Drawing.Size(138, 23);
            this.CreateHomeworkButton.TabIndex = 0;
            this.CreateHomeworkButton.Text = "Create Homework";
            this.CreateHomeworkButton.UseVisualStyleBackColor = true;
            this.CreateHomeworkButton.Click += new System.EventHandler(this.CreateHomeworkButton_Click);
            // 
            // GetStatisticsButton
            // 
            this.GetStatisticsButton.Location = new System.Drawing.Point(61, 189);
            this.GetStatisticsButton.Name = "GetStatisticsButton";
            this.GetStatisticsButton.Size = new System.Drawing.Size(138, 23);
            this.GetStatisticsButton.TabIndex = 1;
            this.GetStatisticsButton.Text = "Get Statistics";
            this.GetStatisticsButton.UseVisualStyleBackColor = true;
            this.GetStatisticsButton.Click += new System.EventHandler(this.GetStatisticsButton_Click);
            // 
            // CreateExerciseButton
            // 
            this.CreateExerciseButton.Location = new System.Drawing.Point(61, 90);
            this.CreateExerciseButton.Name = "CreateExerciseButton";
            this.CreateExerciseButton.Size = new System.Drawing.Size(138, 23);
            this.CreateExerciseButton.TabIndex = 2;
            this.CreateExerciseButton.Text = "Create Exercise";
            this.CreateExerciseButton.UseVisualStyleBackColor = true;
            this.CreateExerciseButton.Click += new System.EventHandler(this.CreateExerciseButton_Click);
            // 
            // TeacherOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 424);
            this.Controls.Add(this.CreateExerciseButton);
            this.Controls.Add(this.GetStatisticsButton);
            this.Controls.Add(this.CreateHomeworkButton);
            this.Name = "TeacherOptionsForm";
            this.Text = "TeacherOptionsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateHomeworkButton;
        private System.Windows.Forms.Button GetStatisticsButton;
        private System.Windows.Forms.Button CreateExerciseButton;
    }
}