using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Manager
{
    public partial class Form3 : Form
    {
        private string[] s;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int r))
            {
                MessageBox.Show("Поле артикулу не повинно бути порожнім", "Відсутнє значення поля 'Артикул'", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                Insert();
            }
        }

        private void Insert()
        {
            s = new string[3];
            s[0] = textBox1.Text;
            s[1] = textBox2.Text;
            s[2] = textBox3.Text;
        }

        public string[] Return()
        {
            return s;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
    }
}
