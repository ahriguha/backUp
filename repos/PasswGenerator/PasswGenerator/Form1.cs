using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            getPasswd((int)numericUpDown1.Value);

        }

        private void getPasswd(int pLength)
        {
           
            Random rand = new Random();
            for(int i = 0; i<pLength; i++)
            {
                int a = rand.Next(1, 4);
                switch (a)
                {
                    case 1: { textBox1.Text += (char)rand.Next(48, 58); break; }
                    case 2: { textBox1.Text += (char)rand.Next(65, 91); break; }
                    case 3: { textBox1.Text += (char)rand.Next(97, 123); break; }
                    default: break;
                }
                
            }
            
        }
    }
}
