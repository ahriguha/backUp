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

namespace ElementsControlingTest
{
    public partial class Form1 : Form
    {
        Point zeroPoint;
        bool moving = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

   

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                if (e.Location.X > button1.Location.X + 60)
                    button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);
                else if (e.Location.X < button1.Location.X + 60)
                    button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
                if (e.Location.Y > button1.Location.Y + 30)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + 1);
                else if (e.Location.Y < button1.Location.Y + 30)
                    button1.Location = new Point(button1.Location.X, button1.Location.Y - 1);
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Control control = button1 as Control;
            if (control != null)
            {
                zeroPoint = button1.Location;
                moving = true;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (moving)
            {

                moving = false;

            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            Thread move = new Thread(new ThreadStart(moveBullet));
            
        }
        public void moveBullet()
        {
            Bullet b = new Bullet();
            b.SetBullet(button1.Location);

            this.Controls.Add(b.GetBullet());
            b.GetBullet().BringToFront();
            while (b.GetBullet() != null)
            {
                if (b.GetBullet().Location.X > 0)
                {
                    b.GetBullet().Location = new Point(b.GetBullet().Location.X - 1, b.GetBullet().Location.Y);
                    Thread.Sleep(100);
                }
                else
                    b.GetBullet().Dispose();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
