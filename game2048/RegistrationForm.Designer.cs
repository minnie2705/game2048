using System.Windows.Forms;

namespace game2048
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.RegistrateBut = new System.Windows.Forms.Button();
            this.LoginBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameTextBox.Location = new System.Drawing.Point(43, 184);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(252, 34);
            this.usernameTextBox.TabIndex = 0;
            this.usernameTextBox.Text = "Nickname";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.Location = new System.Drawing.Point(43, 237);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(251, 34);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.Text = "Password";
            // 
            // RegistrateBut
            // 
            this.RegistrateBut.BackColor = System.Drawing.Color.Peru;
            this.RegistrateBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegistrateBut.Location = new System.Drawing.Point(184, 298);
            this.RegistrateBut.Name = "RegistrateBut";
            this.RegistrateBut.Size = new System.Drawing.Size(110, 33);
            this.RegistrateBut.TabIndex = 2;
            this.RegistrateBut.Text = "Registrate";
            this.RegistrateBut.UseVisualStyleBackColor = false;
            this.RegistrateBut.Click += new System.EventHandler(this.RegistrateBut_Click);
            // 
            // LoginBut
            // 
            this.LoginBut.BackColor = System.Drawing.Color.Peru;
            this.LoginBut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginBut.Location = new System.Drawing.Point(43, 298);
            this.LoginBut.Name = "LoginBut";
            this.LoginBut.Size = new System.Drawing.Size(110, 33);
            this.LoginBut.TabIndex = 3;
            this.LoginBut.Text = "Login";
            this.LoginBut.UseVisualStyleBackColor = false;
            this.LoginBut.Click += new System.EventHandler(this.LoginBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(73, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game \"2048\"";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(341, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginBut);
            this.Controls.Add(this.RegistrateBut);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.Text = "RegidtrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button RegistrateBut;
        private Button LoginBut;
        private Label label1;
    }
}