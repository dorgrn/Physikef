namespace physikeffirebaseFE
{
    partial class CreateHomeworkForm
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
            this.CreateHomeWorkButton = new System.Windows.Forms.Button();
            this.HomeWorkNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SceneNameTextBox = new System.Windows.Forms.TextBox();
            this.studentsTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateHomeWorkButton
            // 
            this.CreateHomeWorkButton.Location = new System.Drawing.Point(69, 214);
            this.CreateHomeWorkButton.Name = "CreateHomeWorkButton";
            this.CreateHomeWorkButton.Size = new System.Drawing.Size(130, 23);
            this.CreateHomeWorkButton.TabIndex = 0;
            this.CreateHomeWorkButton.Text = "create homework";
            this.CreateHomeWorkButton.UseVisualStyleBackColor = true;
            this.CreateHomeWorkButton.Click += new System.EventHandler(this.CreateHomeWorkButton_Click);
            // 
            // HomeWorkNameTextBox
            // 
            this.HomeWorkNameTextBox.Location = new System.Drawing.Point(143, 21);
            this.HomeWorkNameTextBox.Name = "HomeWorkNameTextBox";
            this.HomeWorkNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.HomeWorkNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "HomeWorkName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SceneName:";
            // 
            // SceneNameTextBox
            // 
            this.SceneNameTextBox.Location = new System.Drawing.Point(143, 58);
            this.SceneNameTextBox.Name = "SceneNameTextBox";
            this.SceneNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.SceneNameTextBox.TabIndex = 4;
            // 
            // studentsTextBox
            // 
            this.studentsTextBox.Location = new System.Drawing.Point(143, 97);
            this.studentsTextBox.Name = "studentsTextBox";
            this.studentsTextBox.Size = new System.Drawing.Size(100, 96);
            this.studentsTextBox.TabIndex = 5;
            this.studentsTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Students:";
            // 
            // CreateHomeworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.studentsTextBox);
            this.Controls.Add(this.SceneNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HomeWorkNameTextBox);
            this.Controls.Add(this.CreateHomeWorkButton);
            this.Name = "CreateHomeworkForm";
            this.Text = "CreateHomeWorkForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateHomeWorkButton;
        private System.Windows.Forms.TextBox HomeWorkNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SceneNameTextBox;
        private System.Windows.Forms.RichTextBox studentsTextBox;
        private System.Windows.Forms.Label label3;
    }
}