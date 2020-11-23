using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElementsControlingTest
{
    class Bullet
    {
        const int formSizeX = 800, formSizeY = 500;
        Button bullet;
        public void SetBullet(Point rayStart)
        {
            Button bullet = new Button();
            bullet.Size = new Size(15,15);
            bullet.Location = new Point(rayStart.X - 10, rayStart.Y + 30);
            bullet.ForeColor = Color.LightCoral;
            this.bullet = bullet;
        }

        public Button GetBullet()
        {   
            return bullet; 
        }

        public void moveBullet()
        {
            while (this.bullet != null)
            {
                if (this.bullet.Location.X > 0)
                {
                    this.bullet.Location = new Point(this.bullet.Location.X-1, this.bullet.Location.Y);
                    Thread.Sleep(10);
                }
                else
                    this.bullet.Dispose();
            }
        }
       
    }
}
