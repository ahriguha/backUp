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

namespace FuzzyLog
{
    public partial class Form1 : Form
    {
        public string Result;
        public float TempRes1 = 0, TempRes2 = 0;
        public float C1 = 0, C2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void integral_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 44)
                e.Handled = true;
        }
        public bool checkInts(TextBox a, TextBox b, TextBox c, TextBox d)
        {
            if (a.Text==""||b.Text==""||c.Text==""||d.Text=="")     
            {
                MessageBox.Show("Одне чи декілька полів меж інтервалів пусті",
                      "Помилка",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning,
                      MessageBoxDefaultButton.Button1);
                unCheckButt();
                return false;
                
            }
            else if (float.Parse(a.Text) > float.Parse(b.Text) || float.Parse(c.Text) > float.Parse(d.Text)) 
            {
                MessageBox.Show("Некорректні значення меж інтервалів",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                unCheckButt();
                return false;
            }
            else
            return true;
        }

        private void zeroDivision() {
            MessageBox.Show("Ділення на ноль заборонено",
                       "Помилка",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error,
                       MessageBoxDefaultButton.Button1);
        }
        private void unCheckButt() {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("\tЦя програма дає можливість виконати прості\n\tарифметичні операції над інтервалами довіри.\n" +
               "\tІнтервал довіри - це проміжок на числовій прямій,\n\t наприклад, проміжок від 2 до 6.\n\n" +
               "Для того, щоб виконати розрахунок, введіть значення границь інтервалів до відведених полів, \n" +
               "при цьому зверніть увагу, що ліва межа інтервалу не може бути більше правої межі.\n\n" +
               "Після цього виберіть варіант арифметичної операції зі списку, та натисніть на кнопку 'Розрахувати'. \n\n" +
               "Для візуалізації результата необхідно натиснути на кнопку 'Графік'.\n\n" +
               "Для того, щоб виконати дію над трьома і більше інтервалами, \n" +
               "після виконання частини задачі, натисніть на кнопку \n'Результат до А/В'\n" +
               "та виконайте частину, що залишилася. \tПриклад:\n\n" +
               "(A+B)/C -> Виконайте A+B та натисніть 'Результат до А' ->\n" +
               "-> Виконайте А/С -> Отримайте остаточну відповідь.",
                       "Manual",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {//a1            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {//a2
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {//b1

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {//b2

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {//const

        }

        private void radioButton5_Click(object sender, EventArgs e)
        {//A+B
            if (radioButton5.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    float resA = a1 + b1, resB = a2 + b2;
                    TempRes1 = resA;
                    TempRes2 = resB;
                    Result = $"A(+)B = [{resA.ToString()} , {resB.ToString()}]";

                }
                else
                    radioButton5.Checked = false;
            }
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {//A-B
            if (radioButton4.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    float resA = a1 - b2, resB = a2 - b1;
                    TempRes1 = resA;
                    TempRes2 = resB;
                    Result = $"A(-)B = [{resA.ToString()} , {resB.ToString()}]";
                }
                else
                    radioButton5.Checked = false;
            }
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {//A*B
            if (radioButton1.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    float[] res = new float[4];
                    res[0] = a1 * b1;
                    res[1] = a1 * b2;
                    res[2] = a2 * b1;
                    res[3] = a2 * b2;
                    float min = 99999, max = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (res[i] < min) { min = res[i]; }
                        if (res[i] > max) { max = res[i]; }
                    }
                    TempRes1 = min;
                    TempRes2 = max;
                    Result = $"A(*)B = [{min.ToString()} , {max.ToString()}]";
                    min = 99999;
                    max = 0;
                }
                else
                    radioButton5.Checked = false;
            }
        }  
        private void radioButton7_Click(object sender, EventArgs e)
        {//A/B
            if (radioButton7.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    if (b1 == 0 || b2 == 0) { zeroDivision(); 
                        radioButton7.Checked = false;}
                    else
                    {
                        float resA = a1 / b2, resB = a2 / b1;
                        TempRes1 = resA;
                        TempRes2 = resB;
                        Result = $"A(/)B = [{resA.ToString()} , {resB.ToString()}]";
                    }
                }
                else
                    radioButton7.Checked = false;
            }
        }
        private void radioButton3_Click(object sender, EventArgs e)
        {//A(Maximum)B
            if (radioButton3.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    float resA, resB;
                    if (a1 < b1) { resA = a1; } else { resA = b1; }
                    if (a2 > b2) { resB = a2; } else { resB = b2; }
                    TempRes1 = resA;
                    TempRes2 = resB;
                    Result = $"A(MAX)B = [{resA.ToString()} , {resB.ToString()}]";
                }
                else
                    radioButton5.Checked = false;
            }
        } 
        private void radioButton6_Click(object sender, EventArgs e)
        {//A(Minimum)B
            if (radioButton6.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    float resA, resB;
                    if (a1 > b1) { resA = a1; } else { resA = b1; }
                    if (a2 < b2) { resB = a2; } else { resB = b2; }
                    TempRes1 = resA;
                    TempRes2 = resB;
                    Result = $"A(MIN)B = [{resA.ToString()} , {resB.ToString()}]";
                }
                else
                    radioButton6.Checked = false;
            }
        }   
        private void radioButton2_Click(object sender, EventArgs e)
        {//A*const   
            if (radioButton2.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    Form2 newForm = new Form2(this);
                    newForm.ShowDialog();
                    if (newForm.DialogResult == DialogResult.OK) textBox6.Text = newForm.ReturnData();
                    float k = float.Parse(textBox6.Text);
                    float a1 = float.Parse(textBox1.Text) * k, a2 = float.Parse(textBox2.Text) * k;
                    TempRes1 = a1;
                    TempRes2 = a2;
                    Result = $"A(*)const = [{a1.ToString()} , {a2.ToString()}]";
                }
                else
                    radioButton2.Checked = false;
            }
        } 
        private void radioButton8_Click(object sender, EventArgs e)
        {//B/const
            if (radioButton8.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    Form2 newForm = new Form2(this);
                    newForm.ShowDialog();
                    if (newForm.DialogResult == DialogResult.OK) textBox6.Text = newForm.ReturnData();
                    if (float.Parse(textBox6.Text) == 0)
                    {
                        zeroDivision();
                        radioButton8.Checked = false;
                    }
                    else
                    {
                        float k = 1 / float.Parse(textBox6.Text);
                        float b1 = float.Parse(textBox3.Text) * k, b2 = float.Parse(textBox4.Text) * k;
                        TempRes1 = b1;
                        TempRes2 = b2;
                        Result = $"B(/)const = [{b1.ToString()} , {b2.ToString()}]";
                    }
                }
                else
                    radioButton8.Checked = false;
            }
        }
        private void radioButton9_Click(object sender, EventArgs e)
        {//A+const
            if (radioButton9.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    Form2 newForm = new Form2(this);
                    newForm.ShowDialog();
                    if (newForm.DialogResult == DialogResult.OK) textBox6.Text = newForm.ReturnData();
                    float k = float.Parse(textBox6.Text);
                    float a1 = float.Parse(textBox1.Text) + k, a2 = float.Parse(textBox2.Text) + k;
                    TempRes1 = a1;
                    TempRes2 = a2;
                    Result = $"A(+)const = [{a1.ToString()} , {a2.ToString()}]";
                }
                else
                    radioButton9.Checked = false;
            }
        }
        private void radioButton10_Click(object sender, EventArgs e)
        {//B-const
            if (radioButton10.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    Form2 newForm = new Form2(this);

                    newForm.ShowDialog();
                    if (newForm.DialogResult == DialogResult.OK) textBox6.Text = newForm.ReturnData();
                    float k = float.Parse(textBox6.Text);
                    float b1 = float.Parse(textBox3.Text) - k, b2 = float.Parse(textBox4.Text) - k;
                    TempRes1 = b1;
                    TempRes2 = b2;
                    Result = $"B(-)const = [{b1.ToString()} , {b2.ToString()}]";
                }
                else
                    radioButton10.Checked = false;
            }
        }
        private void radioButton11_Click(object sender, EventArgs e)
        {//A(Inverce)
            if (radioButton11.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    if (a1 == 0 || a2 == 0)
                    {
                        zeroDivision();
                        radioButton11.Checked = false;
                    }
                    else if ((a1 < 0 && a2 > 0) || (a1 > 0 && a2 < 0))
                    {
                        MessageBox.Show("Неможливе ділення!\nЗначення повинно бути в множині R+",
                        "Помилка!",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                        unCheckButt();
                    }
                    else
                    {
                        float resA = 1 / a2, resB = 1 / a1;
                        TempRes1 = resA;
                        TempRes2 = resB;
                        Result = $"A(Inverse) = [{resA.ToString()} , {resB.ToString()}]";
                    }
                }
                else
                    radioButton11.Checked = false;
            }
        }
        private void radioButton12_Click(object sender, EventArgs e)
        {//Arefl
            if (radioButton12.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float resA = a1 * (-1), resB = a2 * (-1);
                    if (a1 <= 0)
                    {
                        resA = a2 * (-1);
                        resB = a1 * (-1);
                    }
                    else 
                    {
                        resA = a2 * (-1);
                        resB = a1 * (-1);
                    }

                    
                    TempRes1 = resA;
                    TempRes2 = resB;
                    Result = $"A(Refl) = [{resA.ToString()} , {resB.ToString()}]";
                }
                else
                    radioButton12.Checked = false;
            }
        } 
        private void radioButton13_Click(object sender, EventArgs e)
        {//A/BHyp
            if (radioButton13.Checked)
            {
                if (checkInts(textBox1, textBox2, textBox3, textBox4))
                {
                    float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                    float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                    if (b1 == 0 || b2 == 0) { zeroDivision(); }
                    else if (a1 <= 0 || a2 <= 0 || b1 <= 0 || b2 <= 0)
                    {
                        MessageBox.Show("Неможливе ділення!\nЗначення повинно бути в множині R+",
                        "Помилка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                        unCheckButt();
                    }
                    else
                    {

                        float[] res = new float[4];
                        res[0] = a1 / b1;
                        res[1] = a1 / b2;
                        res[2] = a2 / b1;
                        res[3] = a2 / b2;
                        float min = 99999, max = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            if (res[i] < min) { min = res[i]; }
                            if (res[i] > max) { max = res[i]; }
                        }
                        TempRes1 = min;
                        TempRes2 = max;
                        Result = $"A(/)B(Гiпотеза) = [{min.ToString()} , {max.ToString()}]";
                        min = 99999;
                        max = 0;
                    }
                }
                else
                { radioButton13.Checked = false;}
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {//result   
        }

        private void button2_Click(object sender, EventArgs e)
        {//Res to A
            textBox1.Text = TempRes1.ToString();
            textBox2.Text = TempRes2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Res to B
            textBox3.Text = TempRes1.ToString();
            textBox4.Text = TempRes2.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Result Button
            textBox5.Text = Result;           
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pen AxisPen = new Pen(Color.Black, 1);
            AxisPen.EndCap = LineCap.ArrowAnchor;
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(AxisPen, 0, 70, 245, 70);
            g.DrawLine(AxisPen, 125, 140, 125, 1);

            int zero1 = 125, zero2 = 70;
            if (checkInts(textBox1, textBox2, textBox3, textBox4))
            {
                float a1 = float.Parse(textBox1.Text);
                float a2 = float.Parse(textBox2.Text);
                float b1 = float.Parse(textBox3.Text);
                float b2 = float.Parse(textBox4.Text);
                float r1 = TempRes1;
                float r2 = TempRes2;

                float resc1 = C1;
                float resc2 = C2;
                if ((a2 - a1) < 10 || (b2 - b1) < 10) { a1 *= 10; a2 *= 10; b1 *= 10; b2 *= 10; r1 *= 10; r2 *= 10; }
                else if ((a2 - a1) > 100 || (b2 - b1) > 100) { a1 /= 10; a2 /= 10; b1 /= 10; b2 /= 10; r1 /= 10; r2 /= 10; }
                Pen Graph1 = new Pen(Color.Green, 3);
                g.DrawLine(Graph1, zero1 + a1, zero2 - 5, zero1 + a2, zero2 - 5);

                Pen Graph2 = new Pen(Color.Red, 3);
                g.DrawLine(Graph2, zero1 + b1, zero2 + 5, zero1 + b2, zero2 + 5);

                Pen Graph3 = new Pen(Color.BlueViolet, 3);
                g.DrawLine(Graph3, zero1 + r1, zero2, zero1 + r2, zero2);
                if (radioButton14.Checked)
                {
                    if ((resc2 - resc1) < 10)
                    { resc1 *= 10; resc2 *= 10; }
                    else if ((resc2 - resc1) > 100) { resc1 /= 10; resc2 /= 10; }
                    Pen Graph4 = new Pen(Color.Brown, 3);
                    g.DrawLine(Graph4, zero1 + resc1, zero2 + 10, zero1 + resc2, zero2 + 10);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            Result = null;
            unCheckButt();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tЦя програма дає можливість виконати прості\n\tарифметичні операції над інтервалами довіри.\n" +
               "\tІнтервал довіри - це проміжок на числовій прямій,\n\t наприклад, проміжок від 2 до 6.\n\n" +
               "Для того, щоб виконати розрахунок, введіть значення границь інтервалів до відведених полів, \n" +
               "при цьому зверніть увагу, що ліва межа інтервалу не може бути більше правої межі.\n\n" +
               "Після цього виберіть варіант арифметичної операції зі списку, та натисніть на кнопку 'Розрахувати'. \n\n" +
               "Для візуалізації результата необхідно натиснути на кнопку 'Графік'.\n\n" +
               "Для того, щоб виконати дію над трьома і більше інтервалами, \n" +
               "після виконання частини задачі, натисніть на кнопку \n'Результат до А/В'\n" +
               "та виконайте частину, що залишилася. \tПриклад:\n\n" +
               "(A+B)/C -> Виконайте A+B та натисніть 'Результат до А' ->\n" +
               "-> Виконайте А/С -> Отримайте остаточну відповідь.",
                      "Manual",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1);
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            {//ABC
                if (radioButton14.Checked)
                {
                    if (checkInts(textBox1, textBox2, textBox3, textBox4))
                    {
                        float a1 = float.Parse(textBox1.Text), a2 = float.Parse(textBox2.Text);
                        float b1 = float.Parse(textBox3.Text), b2 = float.Parse(textBox4.Text);
                        float c1 = 1, c2 = 1;
                        Form2 newForm = new Form2(this);
                        newForm.Form2_MultiMul();
                        newForm.ShowDialog();
                        if (newForm.DialogResult == DialogResult.OK)
                        {
                            c1 = newForm.ReturnC1();
                            c2 = newForm.ReturnC2();

                        }
                        float[] res = new float[8];
                        res[0] = a1 * b1 * c1;
                        res[1] = a1 * b1 * c2;
                        res[2] = a1 * b2 * c1;
                        res[3] = a1 * b2 * c2;
                        res[4] = a2 * b1 * c1;
                        res[5] = a2 * b1 * c2;
                        res[6] = a2 * b2 * c1;
                        res[7] = a2 * b2 * c2;
                        float min = 99999, max = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            if (res[i] < min) { min = res[i]; }
                            if (res[i] > max) { max = res[i]; }
                        }
                        TempRes1 = min;
                        TempRes2 = max;
                        C1 = c1;
                        C2 = c2;
                        Result = $"A()B()C = [{min.ToString()} , {max.ToString()}]";

                    }
                    else
                        radioButton14.Checked = false;
                }
                else
                    radioButton14.Checked = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
