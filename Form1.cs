using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameVisualStudioC_Sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Ball_x = 4;
        int Ball_y = 4;
        int score = 0;

        private void GameOver()
        {
            if(score > 32)
            {
                timer1.Stop();
                MessageBox.Show("Você Venceu!");
            }

            if (Bal.Top + Bal.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Game Over");
            }
        }

        private void Get_Score()
        {
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "block")
                {
                    if (Bal.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        Ball_y = -Ball_y;
                        score++;
                        lb_Score.Text = $"Score: {score}";
                    }
                }
            }
        }

        private void Ball_Move()
        {
            Bal.Left += Ball_x;
            Bal.Top += Ball_y;
            if (Bal.Left + Bal.Width > ClientSize.Width || Bal.Left < 0)
            {
                Ball_x = -Ball_x;
            }

            if (Bal.Top < 0 || Bal.Bounds.IntersectsWith(Player.Bounds))
            {
                Ball_y = -Ball_y;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 2;
            if(e.KeyCode == Keys.Left && Player.Left > 0)
            {
                Player.Left -= 5 * speed;
            }

            if (e.KeyCode == Keys.Right && Player.Right < 805)
            {
                Player.Left += 5 * speed;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Ball_Move();
            Get_Score();
            GameOver();
        }
    }
}
