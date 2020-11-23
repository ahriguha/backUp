using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLog3
{
    public partial class Form1 : Form
    {
        private void integral_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 44)
                e.Handled = true;
        }

        float a1, a2, a3;
        float b1, b2, b3;
        float Coord = 0;
        float v = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order();
            draw();
            button1.Enabled = false;
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (float.Parse(textBox1.Text) >= 50)
            {
                b1 = rand.Next(1, ((int)v / 4));
                b2 = rand.Next((int)b1, ((int)v / 4));
                b3 = rand.Next((int)b2, ((int)v / 4));
                draw();
                button1.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Значение должно быть больше 50", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = null;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            float a;
            if (float.TryParse(textBox1.Text, out a))
            {
               
                    a3 = a2 = a1 = float.Parse(textBox1.Text);
                    Coord = 574 / (a1 * 1.1f);
                    v = a1;
            }
            else
            {               
                MessageBox.Show("Введите корректное значение", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                textBox1.Text = null;
            }
        }

        private void order()
        {  
            

         if (b3 <= a1)
            {
                a3 -= b1;
                a2 -= b2;
                a1 -= b3;
            }
            else {
                MessageBox.Show("Not enough fuel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Enabled = true;
            }
           
        }
        private void draw()
        {
           
            
            label1.Text = "Количество топлива - "+"["+a1+", "+a2+", "+a3+"]"+"\nЗаказ порта - "+
                "[" + b1 + ", " + b2 + ", " + b3 + "]";
            Pen AxisPen = new Pen(Color.Black, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.FromArgb(185,209,233));
            g.DrawLine(AxisPen, 4, 0, 4, 200);
            g.DrawLine(AxisPen, 0, 180, 580, 180);

            Pen FuelPen = new Pen(Color.Blue, 3);
            g.DrawLine(FuelPen, a1 * Coord, 180, a2 * Coord, 100);
            g.DrawLine(FuelPen, a2 * Coord, 100, a3 * Coord, 180);

            Pen OrderPen = new Pen(Color.Red, 3);
            g.DrawLine(OrderPen, b1 * Coord, 180, b2 * Coord, 100);
            g.DrawLine(OrderPen, b2 * Coord, 100, b3 * Coord, 180);

        }
    }
}
