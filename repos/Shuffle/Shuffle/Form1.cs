using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shuffle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            string line = textBox1.Text;
            string[] split = line.Split(new Char[] { '\n' });
            Random random = new Random();
            int n = split.Length;
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                string temp = split[i];
                split[i] = split[n];
                split[n] = temp;
            }

            foreach (string s in split)
            {
                if (s.Trim() != "")
                    textBox2.Text += s + "\n";
            }
        }
    }
}
