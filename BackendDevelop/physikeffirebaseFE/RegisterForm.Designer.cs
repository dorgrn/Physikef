namespace physikeffirebaseFE
{
    partial class RegisterForm
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
            this.RegistrationUserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegistrationPasswordLabel = new System.Windows.Forms.Label();
            this.StudentRadioButton = new System.Windows.Forms.RadioButton();
            this.TeacherRadioButton = new System.Windows.Forms.RadioButton();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.UserTypeGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.UserTypeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistrationUserNameLabel
            // 
            this.RegistrationUserNameLabel.AutoSize = true;
            this.RegistrationUserNameLabel.Location = new System.Drawing.Point(32, 55);
            this.RegistrationUserNameLabel.Name = "RegistrationUserNameLabel";
            this.RegistrationUserNameLabel.Size = new System.Drawing.Size(57, 13);
            this.RegistrationUserNameLabel.TabIndex = 0;
            this.RegistrationUserNameLabel.Text = "UserName";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(142, 55);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(142, 95);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 2;
            // 
            // RegistrationPasswordLabel
            // 
            this.RegistrationPasswordLabel.AutoSize = true;
            this.RegistrationPasswordLabel.Location = new System.Drawing.Point(35, 101);
            this.RegistrationPasswordLabel.Name = "RegistrationPasswordLabel";
            this.RegistrationPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.RegistrationPasswordLabel.TabIndex = 3;
            this.RegistrationPasswordLabel.Text = "Password";
            // 
            // StudentRadioButton
            // 
            this.StudentRadioButton.AutoSize = true;
            this.StudentRadioButton.Location = new System.Drawing.Point(3, 19);
            this.StudentRadioButton.Name = "StudentRadioButton";
            this.StudentRadioButton.Size = new System.Drawing.Size(62, 17);
            this.StudentRadioButton.TabIndex = 4;
            this.StudentRadioButton.TabStop = true;
            this.StudentRadioButton.Text = "Student";
            this.StudentRadioButton.UseVisualStyleBackColor = true;
            // 
            // TeacherRadioButton
            // 
            this.TeacherRadioButton.AutoSize = true;
            this.TeacherRadioButton.Location = new System.Drawing.Point(71, 19);
            this.TeacherRadioButton.Name = "TeacherRadioButton";
            this.TeacherRadioButton.Size = new System.Drawing.Size(65, 17);
            this.TeacherRadioButton.TabIndex = 5;
            this.TeacherRadioButton.TabStop = true;
            this.TeacherRadioButton.Text = "Teacher";
            this.TeacherRadioButton.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(94, 255);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 23);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(142, 142);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 7;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(35, 149);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(21, 13);
            this.IdLabel.TabIndex = 8;
            this.IdLabel.Text = "ID:";
            // 
            // UserTypeGroup
            // 
            this.UserTypeGroup.Controls.Add(this.StudentRadioButton);
            this.UserTypeGroup.Controls.Add(this.TeacherRadioButton);
            this.UserTypeGroup.Location = new System.Drawing.Point(68, 187);
            this.UserTypeGroup.Name = "UserTypeGroup";
            this.UserTypeGroup.Size = new System.Drawing.Size(137, 46);
            this.UserTypeGroup.TabIndex = 9;
            this.UserTypeGroup.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Email:";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(142, 20);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(100, 20);
            this.EmailTextBox.TabIndex = 11;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 450);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserTypeGroup);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.RegistrationPasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.RegistrationUserNameLabel);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.UserTypeGroup.ResumeLayout(false);
            this.UserTypeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegistrationUserNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label RegistrationPasswordLabel;
        private System.Windows.Forms.RadioButton StudentRadioButton;
        private System.Windows.Forms.RadioButton TeacherRadioButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.GroupBox UserTypeGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EmailTextBox;
    }
}