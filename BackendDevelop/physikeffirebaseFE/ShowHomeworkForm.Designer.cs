namespace physikeffirebaseFE
{
    partial class ShowHomeworkForm
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
            this.HomeworkListBox = new System.Windows.Forms.ListBox();
            this.SelectHomeworkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomeworkListBox
            // 
            this.HomeworkListBox.FormattingEnabled = true;
            this.HomeworkListBox.Location = new System.Drawing.Point(71, 35);
            this.HomeworkListBox.Name = "HomeworkListBox";
            this.HomeworkListBox.Size = new System.Drawing.Size(120, 160);
            this.HomeworkListBox.TabIndex = 0;
            // 
            // SelectHomeworkButton
            // 
            this.SelectHomeworkButton.Location = new System.Drawing.Point(91, 219);
            this.SelectHomeworkButton.Name = "SelectHomeworkButton";
            this.SelectHomeworkButton.Size = new System.Drawing.Size(75, 23);
            this.SelectHomeworkButton.TabIndex = 1;
            this.SelectHomeworkButton.Text = "Select";
            this.SelectHomeworkButton.UseVisualStyleBackColor = true;
            this.SelectHomeworkButton.Click += new System.EventHandler(this.SelectHomeworkButton_Click);
            // 
            // ShowHomeworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 450);
            this.Controls.Add(this.SelectHomeworkButton);
            this.Controls.Add(this.HomeworkListBox);
            this.Name = "ShowHomeworkForm";
            this.Text = "ShowHomeworkForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HomeworkListBox;
        private System.Windows.Forms.Button SelectHomeworkButton;
    }
}