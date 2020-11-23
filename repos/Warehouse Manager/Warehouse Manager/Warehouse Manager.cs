using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Windows.Forms;

namespace Warehouse_Manager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet.table1". При необходимости она может быть перемещена или удалена.
            this.table1TableAdapter.Fill(this.warehouseDataSet.table1);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {




        }

        private void table1BindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.table1BindingSource1.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.warehouseDataSet1);
                progressBar1.Visible = true;
                while (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value++;
                    Thread.Sleep(5);
                }
                progressBar1.Value = 0;
                progressBar1.Visible = false;
            }
            catch { }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "warehouseDataSet1.table1". При необходимости она может быть перемещена или удалена.
            this.table1TableAdapter1.Fill(this.warehouseDataSet1.table1);

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            table1BindingSource1.Filter = null;
            this.table1TableAdapter1.Fill(this.warehouseDataSet1.table1);
        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form3 ins = new Form3();
            if (ins.ShowDialog(this) == DialogResult.OK)
            {
                string[] s = ins.Return();
                table1TableAdapter1.Insert(int.Parse(s[0]), s[1], int.Parse(s[2]));
                this.table1TableAdapter1.Fill(this.warehouseDataSet1.table1);
            }
            else
            {
                table1BindingSource1.RemoveCurrent();
            }
        }


        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити цей запис?", "Попередження", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                table1BindingSource1.RemoveCurrent();

        }

        private void Search()
        {
            if (int.TryParse(textBox1.Text, out int r))
            {
                table1BindingSource1.Filter = "i_id = " + r;
            }
            else
            {
                table1BindingSource1.Filter = "[i_name] Like'%" + textBox1.Text + "%'";
            }
            this.table1TableAdapter1.Fill(this.warehouseDataSet1.table1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) Search();
        }

        private void table1DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = table1DataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = table1DataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = table1DataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool validated = false;
            try
            {
                foreach (DataGridViewRow row in table1DataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString() == textBox2.Text)
                    {
                        MessageBox.Show("Товар з таким артикулом вже існує. Спробуйте ще раз",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        validated = true;
                    }
                   
                }
                if (validated)
                {
                    table1DataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
                    table1DataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
                    table1DataGridView1.CurrentRow.Cells[3].Value = textBox4.Text;
                    table1BindingSource1.EndEdit();
                    this.table1TableAdapter1.Update(this.warehouseDataSet1);
                }
                
            }
            catch { }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ви впевнені, що бажаєте вийти?", "Попередження", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)

        {
            if (System.Windows.Forms.Application.OpenForms["Form4"] == null)
            {
                Form4 f = new Form4();
                f.Show();
                f.SetAmount(GetGeneralAmount());
            }
            else
            {
                System.Windows.Forms.Application.OpenForms["Form4"].Close();
                Form4 f = new Form4();
                f.Show();
                f.SetAmount(GetGeneralAmount());
            }
           
            
        }

        void SaveTable(DataGridView What_save)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Склад.xlsx";

            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelapp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = 1; i < What_save.RowCount + 1; i++)
            {
                for (int j = 1; j < table1DataGridView1.ColumnCount + 1; j++)
                {
                    worksheet.Rows[i].Columns[j] = What_save.Rows[i - 1].Cells[j - 1].Value;
                }
            }
            excelapp.AlertBeforeOverwriting = false;
            try
            {
                workbook.SaveAs(path);
            }
            catch { try { workbook.Save(); } catch { } }
            excelapp.Quit();

        }

        private int GetGeneralAmount()
        {
            int r = 0;
            foreach (DataGridViewRow row in table1DataGridView1.Rows)
            {
                r += int.Parse(row.Cells[3].Value.ToString());
            }
            return r;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveTable(table1DataGridView1);
        }
    }
}
