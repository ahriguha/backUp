using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurGame
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            if (Form1.item1[0]) { pictureBox1.Visible = false; pictureBox1.Enabled = false; }
            if (Form1.item1[1]) { pictureBox2.Visible = false; pictureBox2.Enabled = false; }
            if (Form1.item1[2]) { pictureBox3.Visible = false; pictureBox3.Enabled = false; }
            if (Form1.item1[3]) { pictureBox4.Visible = false; pictureBox4.Enabled = false; }
            if (Form1.item1[4]) { pictureBox5.Visible = false; pictureBox5.Enabled = false; }
            if (Form1.item1[5]) { pictureBox6.Visible = false; pictureBox6.Enabled = false; }
            if (Form1.item1[6]) { pictureBox7.Visible = false; pictureBox7.Enabled = false; }
            if (Form1.item1[7]) { pictureBox8.Visible = false; pictureBox8.Enabled = false; }
            if (Form1.item1[8]) { pictureBox9.Visible = false; pictureBox9.Enabled = false; }
            if (Form1.item1[9]) { pictureBox10.Visible = false; pictureBox10.Enabled = false; }
            if (Form1.item1[10]) { pictureBox11.Visible = false; pictureBox11.Enabled = false; }
            if (Form1.item1[11]) { pictureBox12.Visible = false; pictureBox12.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
            Form1.item1[0] = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
            Form1.item1[1] = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox3.Enabled = false;
            Form1.item1[2] = true;
        }
    
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox4.Enabled = false;
            Form1.item1[3] = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox5.Enabled = false;
            Form1.item1[4] = true;
        }
       
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            pictureBox6.Enabled = false;
            Form1.item1[5] = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            pictureBox7.Enabled = false;
            Form1.item1[6] = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox8.Enabled = false;
            Form1.item1[7] = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Visible = false;
            pictureBox9.Enabled = false;
            Form1.item1[8] = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Visible = false;
            pictureBox10.Enabled = false;
            Form1.item1[9] = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
            pictureBox11.Enabled = false;
            Form1.item1[10] = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            pictureBox12.Enabled = false;
            Form1.item1[11] = true;
        }

    }
}
