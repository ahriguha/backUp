using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DataScienceLab2
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {//start data button
            dataGridView1.Rows.Clear();
            
            foreach(RoughData r in RoughData.GetData())
            {
                dataGridView1.Rows.Add(RoughData.GetStringData(r));
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {//anomally cleared data
            dataProcess();
        }

        private void button3_Click(object sender, EventArgs e)
        {//normalized data
            dataNormalize();
        }
        private void button4_Click(object sender, EventArgs e)
        {//one-hot encoding
            dataDummy();
        }

        private void dataProcess()
        {
            List<int> date = new List<int>();
            List<int> temperature = new List<int>();
            List<int> windSpeed = new List<int>();
            List<string> windDir = new List<string>();
            List<double> precip = new List<double>();
            foreach (RoughData r in RoughData.GetData())
            {
                date.Add((int)RoughData.GetArrayData(r)[0]);
                temperature.Add((int)RoughData.GetArrayData(r)[1]);
                windSpeed.Add((int)RoughData.GetArrayData(r)[2]);
                windDir.Add(RoughData.GetArrayData(r)[3].ToString());
                precip.Add((double)RoughData.GetArrayData(r)[4]);
            }

            //date check
            date = checkDate(date);
            //temperature check
            temperature = checkTemperature(temperature);
            //windSpeed check
            windSpeed = checkWSpeed(windSpeed);
            //precip check
            precip = checkPrecip(precip);

            dataGridView1.Rows.Clear();
            for(int i = 0; i< date.Count; i++)
            {
                dataGridView1.Rows.Add(new string[] { 
                    date[i].ToString(), 
                    temperature[i].ToString(),
                    windSpeed[i].ToString(),
                    windDir[i],
                    precip[i].ToString()
                });
            }
        }

        private void dataNormalize()
        {
            List<int> date = new List<int>();
            List<int> temperature = new List<int>();
            List<int> windSpeed = new List<int>();
            List<string> windDir = new List<string>();
            List<double> precip = new List<double>();
            foreach (RoughData r in RoughData.GetData())
            {
                date.Add((int)RoughData.GetArrayData(r)[0]);
                temperature.Add((int)RoughData.GetArrayData(r)[1]);
                windSpeed.Add((int)RoughData.GetArrayData(r)[2]);
                windDir.Add(RoughData.GetArrayData(r)[3].ToString());
                precip.Add((double)RoughData.GetArrayData(r)[4]);
            }

            //date check
            date = checkDate(date);
            //temperature check
            temperature = checkTemperature(temperature);
            //windSpeed check
            windSpeed = checkWSpeed(windSpeed);
            //precip check
            precip = checkPrecip(precip);

            List<double> norTemperature = twpNormalize(temperature);
            List<double> norWindSpeed = twpNormalize(windSpeed);
            List<double> norPrecip = twpNormalize(precip);

            dataGridView1.Rows.Clear();
            for (int i = 0; i < date.Count; i++)
            {
                dataGridView1.Rows.Add(new string[] {
                    date[i].ToString(),
                    norTemperature[i].ToString(),
                    norWindSpeed[i].ToString(),
                    windDir[i],
                    norPrecip[i].ToString()
                });
            }
        }

        private void dataDummy()
        {
            List<int> date = new List<int>();
            List<int> temperature = new List<int>();
            List<int> windSpeed = new List<int>();
            List<string> windDir = new List<string>();
            List<double> precip = new List<double>();
            foreach (RoughData r in RoughData.GetData())
            {
                date.Add((int)RoughData.GetArrayData(r)[0]);
                temperature.Add((int)RoughData.GetArrayData(r)[1]);
                windSpeed.Add((int)RoughData.GetArrayData(r)[2]);
                windDir.Add(RoughData.GetArrayData(r)[3].ToString());
                precip.Add((double)RoughData.GetArrayData(r)[4]);
            }

            //date check
            date = checkDate(date);
            //temperature check
            temperature = checkTemperature(temperature);
            //windSpeed check
            windSpeed = checkWSpeed(windSpeed);
            //precip check
            precip = checkPrecip(precip);

            List<double> norTemperature = twpNormalize(temperature);
            List<double> norWindSpeed = twpNormalize(windSpeed);
            List<double> norPrecip = twpNormalize(precip);

            windDir = dumCode(windDir);

            dataGridView1.Rows.Clear();
            for (int i = 0; i < date.Count; i++)
            {
                dataGridView1.Rows.Add(new string[] {
                    date[i].ToString(),
                    norTemperature[i].ToString(),
                    norWindSpeed[i].ToString(),
                    windDir[i],
                    norPrecip[i].ToString()
                });
            }
        }

        private List<string> dumCode(List<string> windDir)
        {
            for (int i = 0; i < windDir.Count; i++)
            {
                switch (windDir[i])
                {
                    case "North":
                        {
                            windDir[i] = "10000000";
                            break;
                        }
                    case "North-West":
                        {
                            windDir[i] = "01000000";
                            break;
                        }
                    case "West":
                        {
                            windDir[i] = "00100000";
                            break;
                        }
                    case "South-West":
                        {
                            windDir[i] = "00010000";
                            break;
                        }
                    case "South":
                        {
                            windDir[i] = "00001000";
                            break;
                        }
                    case "South-East":
                        {
                            windDir[i] = "00000100";
                            break;
                        }
                    case "East":
                        {
                            windDir[i] = "00000010";
                            break;
                        }
                    case "North-East":
                        {
                            windDir[i] = "00000001";
                            break;
                        }
                    default:
                        {
                            windDir[i] = "00000000";
                            break;
                        }
                }
            }
            return windDir;     }

        private List<double> twpNormalize(List<int> list)
        {
            List<double> lisst = new List<double>();
            int min = int.MaxValue;
            int max = 0;
            foreach(int i in list)
            {
                if (i > max)
                    max = i;
                if (i < min)
                    min = i;
            }
            
            for (int i = 0; i < list.Count; i++)
            {
                lisst.Add(Math.Round((double)(list[i] - min) / (max - min), 5));
            }
            return lisst;
        }
        private List<double> twpNormalize(List<double> list)
        {
            List<double> lisst = new List<double>();
            double min = double.MaxValue;
            double max = 0;
            foreach (double i in list)
            {
                if (i > max)
                    max = i;
                if (i < min)
                    min = i;
            }

            for (int i = 0; i < list.Count; i++)
            {
                lisst.Add(Math.Round((list[i] - min) / (max - min), 4));
            }
            return lisst;
        }

        private List<int> checkDate(List<int> date)
        {
            for(int i = 0; i < date.Count; i++)
            {
                if (i != 0)
                {
                    if (date[i] != date[i - 1] + 1)
                    {
                        date[i] = date[i - 1] + 1;
                    }
                }
            }
            return date;
        }


        private List<int> checkTemperature(List<int> temperature)
        {
            for (int i = 1; i < temperature.Count - 1; i++)
            {
                if(Math.Abs(temperature[i] - temperature[i + 1]) > 5 && Math.Abs(temperature[i] - temperature[i - 1]) > 5)
                {
                    temperature[i] = (temperature[i + 1] + temperature[i - 1])/2;
                }
            }
            return temperature;
        }

        private List<int> checkWSpeed(List<int> windSpeed)
        {
            for (int i = 1; i < windSpeed.Count - 1; i++)
            {
                if (Math.Abs(windSpeed[i] - windSpeed[i + 1]) > 10 && Math.Abs(windSpeed[i] - windSpeed[i - 1]) > 10)
                {
                    windSpeed[i] = (windSpeed[i + 1] + windSpeed[i - 1]) / 2;
                }
            }
            return windSpeed;
        }

        private List<double> checkPrecip(List<double> precip)
        {
            for (int i = 1; i < precip.Count - 1; i++)
            {
                if (Math.Abs(precip[i] - precip[i + 1]) > 3 && Math.Abs(precip[i] - precip[i - 1]) > 3)
                {
                    precip[i] = (precip[i + 1] + precip[i - 1]) / 2;
                }
                precip[i] = Math.Round(precip[i], 1);
            }

            return precip;
        }

        
    }
}
