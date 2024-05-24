using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace game2048
{
    public partial class game : Form
    {
        int SIZE = 6;

        public int[,] map;
        public Label[,] labels;
        public PictureBox[,] pic;
        public int score = 0;
        public string username;
        

        public game(string username)
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKeyboard);
            this.FormClosing += new FormClosingEventHandler(FormClosingHandler);
            this.username = username;
            
            ResizeField();
            map = new int[SIZE, SIZE];
            labels = new Label[SIZE, SIZE];
            pic = new PictureBox[SIZE, SIZE];
            map[0, 0] = 2;
            map[0, 1] = 2;
            NewMap();
            CreatePicture();
            GenPic();
            


        }
        private void UpdateScoreLabel()
        {
            scoreLabel.Text = "Score: " + score.ToString();
        }
        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            SaveScore(username, score);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void NewMap()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Location = new Point(12 + 56 * j, 128 + 56 * i);
                    picture.Size = new Size(50, 50);
                    picture.BackColor = Color.Moccasin;
                    this.Controls.Add(picture);
                }
            }
        }

        private void GenPic()
        {
            Random rnd = new Random();
            List<Point> emptyCells = new List<Point>();

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (map[i, j] == 0)
                    {
                        emptyCells.Add(new Point(i, j));
                    }
                }
            }

            if (emptyCells.Count == 0) return;

            Point newCell = emptyCells[rnd.Next(emptyCells.Count)];
            int a = newCell.X;
            int b = newCell.Y;

            map[a, b] = 2;
            pic[a, b] = new PictureBox();
            labels[a, b] = new Label();
            labels[a, b].Text = "2";
            labels[a, b].Size = new Size(50, 50);
            labels[a, b].TextAlign = ContentAlignment.MiddleCenter;
            labels[a, b].Font = new Font(new FontFamily("Times New Roman"), 14);
            pic[a, b].Controls.Add(labels[a, b]);
            pic[a, b].Location = new Point(12 + b * 56, 128 + 56 * a);
            pic[a, b].Size = new Size(50, 50);
            pic[a, b].BackColor = Color.Honeydew;
            this.Controls.Add(pic[a, b]);
            pic[a, b].BringToFront();
        }

        private void CreatePicture()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (map[i, j] != 0)
                    {
                        pic[i, j] = new PictureBox();
                        labels[i, j] = new Label();
                        labels[i, j].Text = map[i, j].ToString();
                        labels[i, j].Size = new Size(50, 50);
                        labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                        labels[i, j].Font = new Font(new FontFamily("Times New Roman"), 14);
                        pic[i, j].Controls.Add(labels[i, j]);
                        pic[i, j].Location = new Point(12 + j * 56, 128 + 56 * i);
                        pic[i, j].Size = new Size(50, 50);
                        pic[i, j].BackColor = Color.Honeydew;
                        this.Controls.Add(pic[i, j]);
                        pic[i, j].BringToFront();
                    }
                }
            }
        }

        private void ChangeColor(int sum, int k, int j)
        {
            if (sum % 2048 == 0) pic[k, j].BackColor = Color.Red;
            else if (sum % 1024 == 0) pic[k, j].BackColor = Color.Goldenrod;
            else if (sum % 512 == 0) pic[k, j].BackColor = Color.Gold;
            else if (sum % 256 == 0) pic[k, j].BackColor = Color.Khaki;
            else if (sum % 128 == 0) pic[k, j].BackColor = Color.LemonChiffon;
            else if (sum % 64 == 0) pic[k, j].BackColor = Color.OrangeRed;
            else if (sum % 32 == 0) pic[k, j].BackColor = Color.Salmon;
            else if (sum % 16 == 0) pic[k, j].BackColor = Color.SandyBrown;
            else if (sum % 8 == 0) pic[k, j].BackColor = Color.PeachPuff;
            else pic[k, j].BackColor = Color.Bisque;
        }

        private void SaveScore(string username, int score)
        {
            string filePath = "scores.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{username},{score}");
            }
        }

        private void PressKeyboard(object sender, KeyEventArgs e)
        {
            bool ifPictureMove = false;
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    for (int k = 0; k < SIZE; k++)
                    {
                        for (int l = 2; l >= 0; l--)
                        {
                            if (map[k, l] != 0)
                            {
                                for (int j = l + 1; j < SIZE; j++)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        map[k, j] = map[k, j - 1];
                                        map[k, j - 1] = 0;
                                        pic[k, j] = pic[k, j - 1];
                                        pic[k, j - 1] = null;
                                        labels[k, j] = labels[k, j - 1];
                                        labels[k, j - 1] = null;
                                        if (pic[k, j] != null)
                                            pic[k, j].Location = new Point(pic[k, j].Location.X + 56, pic[k, j].Location.Y);
                                        ifPictureMove = true;
                                    }
                                    else if (map[k, j] == map[k, j - 1])
                                    {
                                        int newValue = map[k, j] + map[k, j - 1];
                                        map[k, j] = newValue;
                                        score += newValue;
                                        ChangeColor(newValue, k, j);
                                        labels[k, j].Text = newValue.ToString();
                                        this.Controls.Remove(pic[k, j - 1]);
                                        this.Controls.Remove(labels[k, j - 1]);
                                        pic[k, j - 1] = null;
                                        labels[k, j - 1] = null;
                                        map[k, j - 1] = 0;
                                        ifPictureMove = true;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "Left":
                    for (int k = 0; k < SIZE; k++)
                    {
                        for (int l = 1; l < SIZE; l++)
                        {
                            if (map[k, l] != 0)
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        map[k, j] = map[k, j + 1];
                                        map[k, j + 1] = 0;
                                        pic[k, j] = pic[k, j + 1];
                                        pic[k, j + 1] = null;
                                        labels[k, j] = labels[k, j + 1];
                                        labels[k, j + 1] = null;
                                        if (pic[k, j] != null)
                                            pic[k, j].Location = new Point(pic[k, j].Location.X - 56, pic[k, j].Location.Y);
                                        ifPictureMove = true;
                                    }
                                    else if (map[k, j] == map[k, j + 1])
                                    {
                                        int newValue = map[k, j] + map[k, j + 1];
                                        map[k, j] = newValue;
                                        score += newValue;
                                        ChangeColor(newValue, k, j);
                                        labels[k, j].Text = newValue.ToString();
                                        this.Controls.Remove(pic[k, j + 1]);
                                        this.Controls.Remove(labels[k, j + 1]);
                                        pic[k, j + 1] = null;
                                        labels[k, j + 1] = null;
                                        map[k, j + 1] = 0;
                                        ifPictureMove = true;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "Down":
                    for (int k = 2; k >= 0; k--)
                    {
                        for (int l = 0; l < SIZE; l++)
                        {
                            if (map[k, l] != 0)
                            {
                                for (int j = k + 1; j < SIZE; j++)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        map[j, l] = map[j - 1, l];
                                        map[j - 1, l] = 0;
                                        pic[j, l] = pic[j - 1, l];
                                        pic[j - 1, l] = null;
                                        labels[j, l] = labels[j - 1, l];
                                        labels[j - 1, l] = null;
                                        if (pic[j, l] != null)
                                            pic[j, l].Location = new Point(pic[j, l].Location.X, pic[j, l].Location.Y + 56);
                                        ifPictureMove = true;
                                    }
                                    else if (map[j, l] == map[j - 1, l])
                                    {
                                        int newValue = map[j, l] + map[j - 1, l];
                                        map[j, l] = newValue;
                                        score += newValue;
                                        ChangeColor(newValue, j, l);
                                        labels[j, l].Text = newValue.ToString();
                                        this.Controls.Remove(pic[j - 1, l]);
                                        this.Controls.Remove(labels[j - 1, l]);
                                        pic[j - 1, l] = null;
                                        labels[j - 1, l] = null;
                                        map[j - 1, l] = 0;
                                        ifPictureMove = true;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "Up":
                    for (int k = 1; k < SIZE; k++)
                    {
                        for (int l = 0; l < SIZE; l++)
                        {
                            if (map[k, l] != 0)
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        map[j, l] = map[j + 1, l];
                                        map[j + 1, l] = 0;
                                        pic[j, l] = pic[j + 1, l];
                                        pic[j + 1, l] = null;
                                        labels[j, l] = labels[j + 1, l];
                                        labels[j + 1, l] = null;
                                        if (pic[j, l] != null)
                                            pic[j, l].Location = new Point(pic[j, l].Location.X, pic[j, l].Location.Y - 56);
                                        ifPictureMove = true;
                                    }
                                    else if (map[j, l] == map[j + 1, l])
                                    {
                                        int newValue = map[j, l] + map[j + 1, l];
                                        map[j, l] = newValue;
                                        score += newValue;
                                        ChangeColor(newValue, j, l);
                                        labels[j, l].Text = newValue.ToString();
                                        
                                        this.Controls.Remove(pic[j + 1, l]);
                                        this.Controls.Remove(labels[j + 1, l]);
                                        pic[j + 1, l] = null;
                                        labels[j + 1, l] = null;
                                        map[j + 1, l] = 0;
                                        ifPictureMove = true;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                break; 

            }
            


            if (!CanMove())
            {
                MessageBox.Show("Игра окончена! Нет возможных ходов.", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SaveScore(username, score);
                this.Close();
            }
            else if (ifPictureMove)
            {
                GenPic();
                UpdateScoreLabel();
            }

        }

        private bool CanMove()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (map[i, j] == 0) return true;
                    if (j < 3 && map[i, j] == map[i, j + 1]) return true;
                    if (i < 3 && map[i, j] == map[i + 1, j]) return true;
                }
            }
            return false;
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIZE = 4;
            ResizeField();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIZE = 5;
            ResizeField();
        }

        private void x6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SIZE = 6;
            ResizeField();
        }

        private void ClearField()
        {
            List<Control> controlsToRemove = new List<Control>();

            foreach (var control in this.Controls)
            {
                if (control is PictureBox || control is Label)
                {
                    controlsToRemove.Add((Control)control);
                }
            }

            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
            }
        }


        private void ResizeField()
        {
            ClearField();

            map = new int[SIZE, SIZE];
            labels = new Label[SIZE, SIZE];
            pic = new PictureBox[SIZE, SIZE];

            map[0, 0] = 2;
            map[0, 1] = 2;
            NewMap();
            CreatePicture();
            GenPic();
            UpdateScoreLabel();
        }

        private void ScoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
