using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PurpleRain
{
    public partial class Form1 : Form
    {
        bool closed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(227, 190, 255);
            this.backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            start();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Thread[] bt = new Thread[40];
            for (int i = 0; i < bt.Length; i++)
            {

                bt[i] = new Thread(new ThreadStart(bgdrop));
               
                bt[i].Start();
            }


        }

        private void tick(int startX, SolidBrush b1,
            SolidBrush b2, SolidBrush b3, SolidBrush b4, SolidBrush b5, SolidBrush b6)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();           
                for (int i = 0; i < 94; i++)
                {
                    if (i < 5)
                    {
                        if (i < 4)
                        {
                            if (i < 3)
                            {
                                if (i < 2)
                                {
                                    if (i < 1)
                                    {
                                        g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                                    }
                                    else
                                    {
                                        g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                                        g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                                    }
                                }
                                else
                                {
                                    g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                                    g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                                    g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                                }
                            }
                            else
                            {
                                g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                                g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                                g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                                g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                            }
                        }
                        else
                        {
                            g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                            g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                            g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                            g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                            g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                        }
                    }
                    else if (i > 88)
                    {
                        if (i > 89)
                        {
                            if (i > 90)
                            {
                                if (i > 91)
                                {
                                    if (i > 92)
                                    {
                                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                                    }
                                    else
                                    {
                                        g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                                    }
                                }
                                else
                                {
                                    g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                                    g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                                    g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                                }
                            }
                            else
                            {
                                g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                                g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                                g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                                g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                            }
                        }
                        else
                        {
                            g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                            g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                            g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                            g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                            g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                        }
                    }
                    else
                    {
                        g.FillRectangle(b1, new RectangleF(startX, i * 5, 5, 5));
                        g.FillRectangle(b2, new RectangleF(startX, i * 5 - 5, 5, 5));
                        g.FillRectangle(b3, new RectangleF(startX, i * 5 - 10, 5, 5));
                        g.FillRectangle(b4, new RectangleF(startX, i * 5 - 15, 5, 5));
                        g.FillRectangle(b5, new RectangleF(startX, i * 5 - 20, 5, 5));
                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 25, 5, 5));
                    }
                    Thread.Sleep(20);
                }
            }
            catch { Application.Exit(); }

        }

        private void bgtick(int startX, SolidBrush b1,
           SolidBrush b2, SolidBrush b3, SolidBrush b4, SolidBrush b5, SolidBrush b6)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();
                for (int i = 0; i < 111; i++)
                {
                    if (i < 5)
                    {
                        if (i < 4)
                        {
                            if (i < 3)
                            {
                                if (i < 2)
                                {
                                    if (i < 1)
                                    {
                                        g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                                    }
                                    else
                                    {
                                        g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                                        g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                                    }
                                }
                                else
                                {
                                    g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                                    g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                                    g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                                }
                            }
                            else
                            {
                                g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                                g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                                g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                                g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                            }
                        }
                        else
                        {
                            g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                            g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                            g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                            g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                            g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                        }
                    }
                    else if (i > 105)
                    {
                        if (i > 106)
                        {
                            if (i > 107)
                            {
                                if (i > 108)
                                {
                                    if (i > 109)
                                    {
                                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                                    }
                                    else
                                    {
                                        g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                                    }
                                }
                                else
                                {
                                    g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                                    g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                                    g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                                }
                            }
                            else
                            {
                                g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                                g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                                g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                                g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                            }
                        }
                        else
                        {
                            g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                            g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                            g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                            g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                            g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                        }
                    }
                    else
                    {
                        g.FillRectangle(b1, new RectangleF(startX, i * 5+1, 4, 4));
                        g.FillRectangle(b2, new RectangleF(startX, i * 5 - 4, 4, 4));
                        g.FillRectangle(b3, new RectangleF(startX, i * 5 - 9, 4, 4));
                        g.FillRectangle(b4, new RectangleF(startX, i * 5 - 14, 4, 4));
                        g.FillRectangle(b5, new RectangleF(startX, i * 5 - 19, 4, 4));
                        g.FillRectangle(b6, new RectangleF(startX, i * 5 - 24, 4, 4));
                    }
                    Thread.Sleep(30);
                }
            }
            catch { Application.Exit(); }

        }
        private void drop()
        {
            
            while (!closed)
            {
                Random rand = new Random();
                Thread.Sleep(rand.Next(0, 5000));
                SolidBrush b1 = new SolidBrush(Color.FromArgb(101, 9, 117));
                SolidBrush b2 = new SolidBrush(Color.FromArgb(158, 29, 180));
                SolidBrush b3 = new SolidBrush(Color.FromArgb(197, 81, 218));
                SolidBrush b4 = new SolidBrush(Color.FromArgb(203, 117, 218));
                SolidBrush b5 = new SolidBrush(Color.FromArgb(201, 139, 211));
                SolidBrush b6 = new SolidBrush(Color.FromArgb(227, 190, 255));

                tick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);
                Thread.Sleep(rand.Next(0, 200));
                tick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);
                Thread.Sleep(rand.Next(0, 200));
                tick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);
                

            }
            
        }
        private void bgdrop()
        {

            while (!closed)
            {
                Random rand = new Random();
                Thread.Sleep(rand.Next(0, 5000));
                SolidBrush b1 = new SolidBrush(Color.FromArgb(101, 89, 117));
                SolidBrush b2 = new SolidBrush(Color.FromArgb(158, 99, 180));
                SolidBrush b3 = new SolidBrush(Color.FromArgb(197, 121, 218));
                SolidBrush b4 = new SolidBrush(Color.FromArgb(203, 167, 218));
                SolidBrush b5 = new SolidBrush(Color.FromArgb(201, 189, 211));
                SolidBrush b6 = new SolidBrush(Color.FromArgb(227, 190, 255));

                bgtick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);
                Thread.Sleep(rand.Next(0, 200));
                bgtick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);
                Thread.Sleep(rand.Next(0, 200));
                bgtick(rand.Next(0, 780), b1, b2, b3, b4, b5, b6);


            }

        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            
        }
        private void start()
        {
 Thread[] t = new Thread[40];
            
            backgroundWorker1.RunWorkerAsync();
            for(int i = 0; i< t.Length; i++)
            {
                t[i] = new Thread(new ThreadStart(drop));
                
                t[i].Start();
               
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
            Application.Exit();
        }
    }
}
