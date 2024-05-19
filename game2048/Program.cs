using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2048
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        static string username;
        static string password;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            using (RegistrationForm registrationForm = new RegistrationForm())
            {
                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    username = registrationForm.Username;
                    password = registrationForm.Password;

                    if (CheckUsernameExists(username))
                    {
                        MessageBox.Show(
                            "Пользователь с таким именем уже существует. Пожалуйста, выберите другое имя пользователя.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SaveUserData(username, password);

                    Application.Run(new game());
                }
                else
                {
                    return;
                }
            }
        }

        static void SaveUserData(string username, string password)
        {
            string filePath = "users.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{username},{password}");
                }

                Console.WriteLine("Данные пользователя сохранены успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении данных пользователя: " + ex.Message);
            }
        }

        public static bool CheckUsernameExists(string username)
        {
            string filePath = "users.txt";

            if (!File.Exists(filePath))
                return false;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 1 && parts[0] == username)
                    return true;
            }

            return false;
        }

    }
}