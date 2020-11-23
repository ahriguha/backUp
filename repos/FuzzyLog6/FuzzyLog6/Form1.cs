using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FuzzyLog6
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

        private void calc()
        { 
            if (float.TryParse(textBox1.Text, out float a1) &&
                float.TryParse(textBox2.Text, out float a2) &&
                float.TryParse(textBox3.Text, out float a3) &&
                float.TryParse(textBox4.Text, out float b1) &&
                float.TryParse(textBox5.Text, out float b2) &&
                float.TryParse(textBox6.Text, out float b3))
            {
                //float a1 = result, a2 = result2, a3 = result3;
                //float b1 = result4, b2 = result5, b3 = result6;
                if (checkBox1.Checked)
                {
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                }
                else
                {
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                    chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                    chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                }
                float da = a3 - a1, db = b3 - b1;
              
                if (int.TryParse(textBox7.Text, out int steps))
                {
                    float D = da > db ? db : da;

                    float stepsize = D / steps;

                    int stepsA = (int)(da / stepsize);
                    int stepsB = (int)(db / stepsize);

                    float[] ax, ay, bx, by, cx, cy;

                    float cMax = 0;

                    float x, y;

                    int i;
                    Show();
                    ax = new float[stepsA + 1];
                    ay = new float[stepsA + 1];
                    bx = new float[stepsB + 1];
                    by = new float[stepsB + 1];
                    cx = new float[ax.Length * bx.Length];
                    cy = new float[ay.Length * by.Length];
                    chart1.ChartAreas[0].AxisX.Interval = (D / steps) * 2;

                    
                   
                        textBox1.Text = "1";
                    
                        func_5(ref ax, ref ay, ref bx, ref by, a1, a2, a3, b1, b2, b3, stepsize);
                   

                    if (radioButton1.Checked)
                    {
                        Sum(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }
                    else if (radioButton2.Checked)
                    { 
                        Substr(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }
                    else if (radioButton3.Checked)
                    {
                        Mul(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }
                    else if (radioButton4.Checked)
                    {
                        Div(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }
                    else if (radioButton5.Checked)
                    {
                        Min(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }
                    else if (radioButton6.Checked)
                    {
                        Max(ref ax, ref bx, ref cx, ref ay, ref by, ref cy, stepsA, stepsB);
                    }

                    //////////int z;
                    //////////for (i = 0, z = 0; i <= stepsA; i++)
                    //////////{
                    //////////    for (int j = 0; j <= stepsB; j++, z++)
                    //////////    {
                    //////////        if (i <= stepsA / 2)
                    //////////        {
                    //////////            float min = 10000;
                    //////////            for (int k = 0; k < 4; k++)
                    //////////            {
                    //////////                if (ax[i] * bx[j] < min)
                    //////////                    min = ax[i] * bx[j];
                    //////////                else if (ax[i] * bx[bx.Length - j - 1] < min)
                    //////////                    min = ax[i] * bx[bx.Length - j - 1];
                    //////////                else if (ax[ax.Length - i - 1] * bx[j] < min)
                    //////////                    min = ax[ax.Length - i - 1] * bx[j];
                    //////////                else if (ax[ax.Length - i - 1] * bx[bx.Length - j - 1] < min)
                    //////////                    min = ax[ax.Length - i - 1] * bx[bx.Length - j - 1];
                    //////////            }
                    //////////            cx[z] = min;
                    //////////        }
                    //////////        else if (i > stepsA / 2)
                    //////////        {
                    //////////            float max = 0;
                    //////////            for (int k = 0; k < 4; k++)
                    //////////            {
                    //////////                if (ax[i] * bx[j] > max)
                    //////////                    max = ax[i] * bx[j];
                    //////////                else if (ax[i] * bx[bx.Length - j - 1] > max)
                    //////////                    max = ax[i] * bx[bx.Length - j - 1];
                    //////////                else if (ax[ax.Length - i - 1] * bx[j] > max)
                    //////////                    max = ax[ax.Length - i - 1] * bx[j];
                    //////////                else if (ax[ax.Length - i - 1] * bx[bx.Length - j - 1] > max)
                    //////////                    max = ax[ax.Length - i - 1] * bx[bx.Length - j - 1];
                    //////////            }
                    //////////            cx[z] = max;
                    //////////        }
                    //////////    }
                    //////////}

                    for (int j = 0; j < cx.Length - 1; j++)
                    {
                        for (i = 0; i < cx.Length - j - 1; i++)
                        {
                            if (cx[i] > cx[i + 1])
                            {
                                Swap(ref cx[i], ref cx[i + 1]);
                                
                                Swap(ref cy[i], ref cy[i + 1]);
                              
                            }

                        }
                    }                   


                    for (i = 1; i < cx.Length; i++)
                    {
                        if (cx[i] != cx[i - 1])
                            cMax++;
                    }


                    float[] cResX = new float[(int)cMax], cResY = new float[(int)cMax];
                    float cMidMax = cy[0];                   

                    for (int q = 1, j = 0; q < cx.Length; q++)
                    {
                        if (cx[q] != cx[q - 1])
                        {
                            if (cy[q] > cMidMax)
                                cMidMax = cy[q];
                            cResX[j] = cx[q - 1];
                            cResY[j] = cMidMax;
                            cMidMax = cy[q];
                            j++;
                        }
                        else
                        {
                            if (cy[q] > cMidMax)
                                cMidMax = cy[q];
                        }
                      
                    }


                    cResX[(int)cMax - 1] = cx[cx.Length - 1];

                    for (i = 0; i < cResX.Length; i++)
                    {
                        chart1.Series[2].Points.AddXY(cResX[i], cResY[i]);

                        textBox111.Text += "X: " + cResX[i] + "     μ(X): " + cResY[i] + "\r\n_____________________\r\n";
                        //label2.Text += bx[i] + "     " + by[i] + "\n";
                    }
                }
                else
                {
                    textBox7.Text = null;
                }
            }
        }
        private void Show() { Class1 c = new Class1();  label8.Text = c.s; }

        private void Sum(ref float[] ax, ref float[] bx, ref float[] cx,
            ref float[] ay, ref float[] by, ref float[] cy,
            int stepsA, int stepsB)
        {

           
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] + bx[j], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }

        private void Substr(ref float[] ax, ref float[] bx, ref float[] cx,
          ref float[] ay, ref float[] by, ref float[] cy,
          int stepsA, int stepsB)
        {
           
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] - bx[bx.Length - j - 1], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }

        private void Mul(ref float[] ax, ref float[] bx, ref float[] cx,
        ref float[] ay, ref float[] by, ref float[] cy,
        int stepsA, int stepsB)
        {


            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] * bx[j], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }
        private void Div(ref float[] ax, ref float[] bx, ref float[] cx,
ref float[] ay, ref float[] by, ref float[] cy,
int stepsA, int stepsB)
        {


            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] / bx[j], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }
        private void Min(ref float[] ax, ref float[] bx, ref float[] cx,
ref float[] ay, ref float[] by, ref float[] cy,
int stepsA, int stepsB)
        {


            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] < bx[j] ? ax[i] : bx[j], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }
        private void Max(ref float[] ax, ref float[] bx, ref float[] cx,
ref float[] ay, ref float[] by, ref float[] cy,
int stepsA, int stepsB)
        {


            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cx[z] = (float)Math.Round(ax[i] > bx[j] ? ax[i] : bx[j], 3);
                }
            }
            for (int i = 0, z = 0; i <= stepsA; i++)
            {
                for (int j = 0; j <= stepsB; j++, z++)
                {
                    cy[z] = (float)Math.Round(ay[i] < by[j] ? ay[i] : by[j], 3);
                }
            }
        }
        private void func_5(ref float[] ax, ref float[] ay, ref float[] bx, ref float[] by,
            float a1, float a2, float a3, float b1, float b2, float b3, float stepsize)
        {
            int i;
            float x, y;
            for (x = a1, i = 0; i < ax.Length; x += stepsize, i++)
            {
                /*if (x > a1 && x <= a2)
                {
                    y = (x - a1) / (a2 - a1);
                }
                else if (x >= a2 && x < a3)
                {
                    y = (a3 - x) / (a3 - a2);
                }
                else
                {
                    y = 0;
                }*/


                float z = (x - a2) / a1;
                y = (float)(1 / (1 + Math.Pow(Math.Abs(z), 2 * a3)));



                ax[i] = x;
                ay[i] = y;
                chart1.Series[0].Points.AddXY(x, y);
                //label1.Text += "x = " + Math.Round(x, 2) + "            y = " + Math.Round(y, 2) + "\n";
            }
            for (x = b1, i = 0; i < bx.Length; x += stepsize, i++)
            {
                //if (x > b1 && x <= b2)
                //{
                //    y = (x - b1) / (b2 - b1);
                //}
                //else if (x >= b2 && x < b3)
                //{
                //    y = (b3 - x) / (b3 - b2);
                //}
                //else
                //{
                //    y = 0;
                //}

                float z = (x - b2) / b1;
                y = (float)(1 / (1 + Math.Pow(Math.Abs(z), 2 * b3)));

                bx[i] = x;
                by[i] = y;
                chart1.Series[1].Points.AddXY(x, y);

            }
        }

      
        private void Swap(ref float e1, ref float e2)
        {
            float temp = e1;
            e1 = e2;
            e2 = temp;
        }

        private void clear()
        {
            chart1.Series[0].Points.Clear();

            chart1.Series[1].Points.Clear();

            chart1.Series[2].Points.Clear();
           
            chart1.Refresh();
            textBox111.Text = null;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            calc();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
