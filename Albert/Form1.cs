using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Albert
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        double x = 0, y = 0;
        double h = 20;
        double t = 0;
        double V = 10;
        const double g = 9.8154;
        bool left, right, up, down, fire;
        int c, z;
        double d, f, l, u;

        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Program_Paint);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = false;
            timer.Interval = 50;
        }

        void timer_Tick(object sender, EventArgs e)
        {
                t += 0.01;
                x = V * t * Math.Cos(h * 3.14 / 180);
                y = V * t * Math.Sin(h * 3.14 / 180) - (g * t * t) / 2;

                f = x * 50;
                label3.Text = f.ToString();
                l = y * 50;
                label4.Text = l.ToString();

                d = t * 10;
                label8.Text = d.ToString();

                z = 5-c;
                label10.Text = z.ToString();

                label12.Text = u.ToString();

                Invalidate();

                if (l > 0 && l < 65 && f > tower.Location.X && f < (tower.Location.X + 40))
                {
                    timer.Stop();                    
                    Point n = tower.Location;
                    n.X += 100;
                    tower.Location = n;
                    c++;
                    x = 0;
                    y = 0;

                    if (c==5)
                    {
                        MessageBox.Show("Конец игры", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Application.Restart();
                    }
                }

                if (y <= 0 | x >= 17.5)
                {
                    timer.Enabled = false;
                }
        }

        void Program_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle((int)(50 * x), (int)(200 - 50 * y), 5, 5));           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            t = 0;
            u++;
            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (h <= 90)
            {
                h = h + 1;
            }
            else
            {
                h = h;
            }
            label1.Text = h.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (h >= 0)
            {
                h = h - 1;
            }
            else
            {
                h = h;
            } 
            label1.Text = h.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (V <= 15)
            {
                V = V + 1;
            }
            else
            {
                V = V;
            }
            label2.Text = V.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (V >= 0)
            {
                V = V - 1;
            }
            else
            {
                V = V;
            }
            label2.Text = V.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer.Enabled == false)
            {
                switch (e.KeyValue)
                {
                    case 'W':
                        {
                            up = true;
                            button2_Click(sender, e);
                            break;
                        }
                    case 'A':
                        {
                            left = true;
                            button5_Click(sender, e);
                            break;
                        }
                    case 'D':
                        {
                            right = true;
                            button4_Click(sender, e);
                            break;
                        }
                    case 'S':
                        {
                            down = true;
                            button3_Click(sender, e);
                            break;
                        }
                    case 32:
                        {
                            fire = true;
                            button1_Click(sender, e);
                            break;
                        }
                }
            }
        }
        }
    }

