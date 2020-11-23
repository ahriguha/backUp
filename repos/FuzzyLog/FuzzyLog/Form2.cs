 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzyLog
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f)
        {
            InitializeComponent();
            
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            
        }
        public void Form2_MultiMul() 
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {//k

        }
        public string ReturnData()
        {
            return (textBox1.Text);
        }

        public float ReturnC1() { return float.Parse(textBox2.Text); }
        public float ReturnC2() { return float.Parse(textBox3.Text); }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Будьласка, заповнiть усi iнтервали!",
                        "Помилка!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    textBox2.Text = null;
                    textBox3.Text = null;
                }
                else if (float.Parse(textBox2.Text) > float.Parse(textBox3.Text))
                {
                    MessageBox.Show("Ви ввели неккоректнi значення границь iнтервала",
                          "Помилка!",
                     MessageBoxButtons.RetryCancel,
                     MessageBoxIcon.Error,
                     MessageBoxDefaultButton.Button1);
                    textBox2.Text = null;
                    textBox3.Text = null;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Будьласка, заповнiть усi iнтервали!",
                        "Помилка!",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                textBox1.Text = null;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {//c1

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {//c2

        }

        private void integral_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 44)
                e.Handled = true;
        }

    }
}
