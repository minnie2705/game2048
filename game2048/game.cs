using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2048
{
    public partial class game : Form
    {
        
        public int[,] map = new int[4, 4];
        public Label[,] labels = new Label[4, 4];
        public PictureBox[,] pic=new PictureBox[4, 4];
        private int score = 0;
        public game()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(PressKeyboard);
            map[0, 0] = 1;
            map[0, 1] = 1;
            NewMap();
            CreatePicture();
            GenPic();
        }

        private void NewMap()
        {
            for (int i = 0; i<4; i++)
            {
                for (int j=0; j<4; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Location= new Point(12+56*j,128+56*i);
                    picture.Size = new Size(50,50);
                    picture.BackColor = Color.Moccasin;
                    this.Controls.Add(picture);
                }
            }
        }

        private void GenPic()
        {
            Random rnd = new Random();
            bool freeCellFound = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pic[i, j] == null)
                    {
                        freeCellFound = true;
                        break;
                    }
                }
                if (freeCellFound) break;
            }
            if (!freeCellFound) return;
            int a = rnd.Next(0,4);
            int b = rnd.Next(0, 4);
            while (pic[a,b]!=null)
            {
                a = rnd.Next(0,4);
                b = rnd.Next(0,4);
            }
            map[a, b] = 1;
            pic[a,b]=new PictureBox();
            labels[a,b] = new Label();
            labels[a, b].Text = "2";
            labels[a,b].Size= new Size(50,50);
            labels[a,b].TextAlign= ContentAlignment.MiddleCenter;
            labels[a, b].Font = new Font(new FontFamily("Times New Roman"), 14);
            pic[a, b].Controls.Add(labels[a,b]);
            pic[a, b].Location = new Point(12 + b * 56, 128 + 56 * a);
            pic[a, b].Size = new Size(50,50);
            pic[a,b].BackColor= Color.Honeydew;
            this.Controls.Add(pic[a,b]);
            pic[a, b].BringToFront();

        }

        private void CreatePicture()
        {
            pic[0,0]= new PictureBox();
            labels[0,0] = new Label();
            labels[0, 0].Text = "2";
            labels[0, 0].Size = new Size(50, 50);
            labels[0, 0].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 0].Font = new Font(new FontFamily("Times New Roman"), 14);
            pic[0, 0].Controls.Add(labels[0, 0]);
            pic[0, 0].Location = new Point(12, 128);
            pic[0, 0].Size = new Size(50, 50);
            pic[0, 0].BackColor = Color.Honeydew;
            this.Controls.Add(pic[0, 0]);
            pic[0, 0].BringToFront();

            pic[0, 1] = new PictureBox();
            labels[0, 1] = new Label();
            labels[0, 1].Text = "2";
            labels[0, 1].Size = new Size(50, 50);
            labels[0, 1].TextAlign = ContentAlignment.MiddleCenter;
            labels[0, 1].Font = new Font(new FontFamily("Times New Roman"), 14);
            pic[0, 1].Controls.Add(labels[0, 1]);
            pic[0, 1].Location = new Point(68, 128);
            pic[0, 1].Size = new Size(50, 50);
            pic[0, 1].BackColor = Color.Honeydew;
            this.Controls.Add(pic[0, 1]);
            pic[0, 1].BringToFront();
        }

        private void ChangeColor(int sum, int k, int j)
        {
            if (sum % 2048 == 0) pic[k,j].BackColor = Color.Red;
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

        private bool CanMove()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map[i, j] == 0)
                        return true;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j < 3 && map[i, j] == map[i, j + 1])
                        return true;
                    if (i < 3 && map[i, j] == map[i + 1, j])
                        return true;
                }
            }

            return false;
        }


        private void PressKeyboard(object sender, KeyEventArgs e)
        {
            bool ifPictureMove = false;
            switch(e.KeyCode.ToString())
            {
                case "Right":
                    for (int k=0; k<4;k++)
                    {
                        for (int l=
                            2; l>=0; l--)
                        {
                            if (map[k, l] == 1)
                            {
                                for(int j=l+1;j<4; j++)
                                {
                                    if (map[k,j]==0)
                                    {
                                        ifPictureMove = true;
                                        map[k,j-1] = 0;
                                        map[k,j] = 1;
                                        pic[k, j] = pic[k,j-1];
                                        labels[k, j] = labels[k,j-1];
                                        labels[k, j - 1] = null;
                                        pic[k,j].Location = new Point(pic[k,j].Location.X+56, pic[k,j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j-1].Text);
                                        if (a == b)
                                        {
                                            ifPictureMove=true;
                                            labels[k,j].Text=(a+b).ToString();
                                            score += (a + b);
                                            ChangeColor(a + b, k, j);
                                            label1.Text = "Score: " + score;
                                            map[k, j - 1] = 0;
                                            this.Controls.Remove(pic[k, j - 1]);
                                            this.Controls.Remove(labels[k, j - 1]);
                                            pic[k, j - 1] = null;
                                            labels[k, j - 1] = null;

                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                    break;
                case "Left":
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 1; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = l - 1; j >= 0; j--)
                                {
                                    if (map[k, j] == 0)
                                    {
                                        ifPictureMove = true;
                                        map[k, j + 1] = 0;
                                        map[k, j] = 1;
                                        pic[k, j] = pic[k, j + 1];
                                        pic[k, j + 1] = null;
                                        labels[k, j] = labels[k, j + 1];
                                        labels[k, j + 1] = null;
                                        pic[k, j].Location = new Point(pic[k, j].Location.X - 56, pic[k, j].Location.Y);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[k, j].Text);
                                        int b = int.Parse(labels[k, j + 1].Text);
                                        if (a == b)
                                        {
                                            ifPictureMove = true;
                                            labels[k, j].Text = (a + b).ToString();
                                            score += (a + b);
                                            ChangeColor(a + b, k, j);
                                            label1.Text = "Score: " + score;
                                            map[k, j + 1] = 0;
                                            this.Controls.Remove(pic[k, j + 1]);
                                            this.Controls.Remove(labels[k, j + 1]);
                                            pic[k, j + 1] = null;
                                            labels[k, j + 1] = null;

                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                    break;
                case "Down":
                    for (int k = 2; k >= 0; k--)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = k + 1; j < 4; j++)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ifPictureMove = true;
                                        map[j - 1, l] = 0;
                                        map[j, l] = 1;
                                        pic[j, l] = pic[j - 1, l];
                                        pic[j - 1, l] = null;
                                        labels[j, l] = labels[j - 1, l];
                                        labels[j - 1, l] = null;
                                        pic[j, l].Location = new Point(pic[j, l].Location.X, pic[j, l].Location.Y + 56);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j - 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPictureMove = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            ChangeColor(a + b, j, l);
                                            label1.Text = "Score: " + score;
                                            map[j - 1, l] = 0;
                                            this.Controls.Remove(pic[j - 1, l]);
                                            this.Controls.Remove(labels[j - 1, l]);
                                            pic[j - 1, l] = null;
                                            labels[j - 1, l] = null;
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                    break;
                case "Up":
                    for (int k = 1; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            if (map[k, l] == 1)
                            {
                                for (int j = k - 1; j >= 0; j--)
                                {
                                    if (map[j, l] == 0)
                                    {
                                        ifPictureMove = true;
                                        map[j + 1, l] = 0;
                                        map[j, l] = 1;
                                        pic[j, l] = pic[j + 1, l];
                                        pic[j + 1, l] = null;
                                        labels[j, l] = labels[j + 1, l];
                                        labels[j + 1, l] = null;
                                        pic[j, l].Location = new Point(pic[j, l].Location.X, pic[j, l].Location.Y - 56);
                                    }
                                    else
                                    {
                                        int a = int.Parse(labels[j, l].Text);
                                        int b = int.Parse(labels[j + 1, l].Text);
                                        if (a == b)
                                        {
                                            ifPictureMove = true;
                                            labels[j, l].Text = (a + b).ToString();
                                            score += (a + b);
                                            ChangeColor(a + b, j, l);
                                            label1.Text = "Score: " + score;
                                            map[j + 1, l] = 0;
                                            this.Controls.Remove(pic[j + 1, l]);
                                            this.Controls.Remove(labels[j + 1, l]);
                                            pic[j + 1, l] = null;
                                            labels[j + 1, l] = null;
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                    break;

            }
            if (ifPictureMove)
            {
                GenPic();
            }
        }
       

        private void Form1_Load(object sender, EventArgs e){}
    }
}
