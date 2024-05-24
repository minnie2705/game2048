using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace game2048
{
    public partial class RegistrationForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public RegistrationForm()
        {
            InitializeComponent();
        }


        private void RegistrateBut_Click(object sender, EventArgs e)
        {
            Username = usernameTextBox.Text;
            Password = passwordTextBox.Text;
            DialogResult = DialogResult.OK;

            Close();
        }

        private void LoginBut_Click(object sender, EventArgs e)
        {
            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            
            if (Program.CheckUsernameExists(enteredUsername))
            {
                
                if (CheckPassword(enteredUsername, enteredPassword))
                {
                    
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {

                    MessageBox.Show("Неправильный пароль. Пожалуйста, повторите попытку.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    passwordTextBox.Text = "";
                    
                    passwordTextBox.Focus();
                }
            }
            else
            {
                
                MessageBox.Show("Пользователь с таким именем не существует. Пожалуйста, зарегистрируйтесь.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
                
                usernameTextBox.Focus();
            }
        }


        private bool CheckPassword(string username, string enteredPassword)
        {
            string filePath = "users.txt";

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 2 && parts[0] == username)
                    {

                        if (parts[1] == enteredPassword)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
