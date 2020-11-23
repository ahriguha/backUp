using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Manager
{
    public partial class Form1 : Form
    {
        private string[] login = new string[100];
        private string[] passw= new string[100];
        private bool signed = false;
        

        public Form1()
        {
            InitializeComponent();
            login[0] = "admin";
            passw[0] = "admin";
            login[1] = "Aleksey_2007";
            passw[1] = "12345";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < login.Length; i++)
            {
                if (textBox1.Text == login[i] && textBox2.Text == passw[i])
                {
                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                    signed = true;
                    break;
                }            
            }
            if (!signed)
            {
                MessageBox.Show("Логін чи пароль введені неправильно.\n Спробуйте ще раз", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ваш логін - admin" +
             "\nВаш пароль - admin ",
             "Information",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information);
        }
    }
}
