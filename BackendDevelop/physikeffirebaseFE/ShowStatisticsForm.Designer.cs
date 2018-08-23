namespace physikeffirebaseFE
{
    partial class ShowStatisticsForm
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
            this.StudentIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowStudentStatisticsButton = new System.Windows.Forms.Button();
            this.StatisticslistView = new System.Windows.Forms.ListView();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StudentIDTextBox
            // 
            this.StudentIDTextBox.Location = new System.Drawing.Point(107, 12);
            this.StudentIDTextBox.Name = "StudentIDTextBox";
            this.StudentIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.StudentIDTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Student ID:";
            // 
            // ShowStudentStatisticsButton
            // 
            this.ShowStudentStatisticsButton.Location = new System.Drawing.Point(213, 10);
            this.ShowStudentStatisticsButton.Name = "ShowStudentStatisticsButton";
            this.ShowStudentStatisticsButton.Size = new System.Drawing.Size(75, 23);
            this.ShowStudentStatisticsButton.TabIndex = 2;
            this.ShowStudentStatisticsButton.Text = "Show";
            this.ShowStudentStatisticsButton.UseVisualStyleBackColor = true;
            this.ShowStudentStatisticsButton.Click += new System.EventHandler(this.ShowStudentStatisticsButton_Click);
            // 
            // StatisticslistView
            // 
            this.StatisticslistView.Location = new System.Drawing.Point(24, 129);
            this.StatisticslistView.Name = "StatisticslistView";
            this.StatisticslistView.Size = new System.Drawing.Size(776, 278);
            this.StatisticslistView.TabIndex = 3;
            this.StatisticslistView.UseCompatibleStateImageBehavior = false;
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.AutoSize = true;
            this.SummaryLabel.Location = new System.Drawing.Point(27, 67);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(53, 13);
            this.SummaryLabel.TabIndex = 4;
            this.SummaryLabel.Text = "Summary:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Details:";
            // 
            // ShowStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SummaryLabel);
            this.Controls.Add(this.StatisticslistView);
            this.Controls.Add(this.ShowStudentStatisticsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StudentIDTextBox);
            this.Name = "ShowStatisticsForm";
            this.Text = "ShowStatisticsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StudentIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowStudentStatisticsButton;
        private System.Windows.Forms.ListView StatisticslistView;
        private System.Windows.Forms.Label SummaryLabel;
        private System.Windows.Forms.Label label2;
    }
}