using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            Graphics graph = pictureBox1.CreateGraphics();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += worker_DoWork;
            bw.RunWorkerAsync();

        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SimpleLife s = new SimpleLife();
            Graphics g = pictureBox1.CreateGraphics();
            Pen Bpen = new Pen(Color.Black, 1);
            Pen Wpen = new Pen(Color.White, 1);
            for (int i = 1; i < 90 - 1; i++)
                for (int j = 1; j < 55 - 1; j++)
                {
                    if (s.field[i, j])
                    {
                        g.FillRectangle(Brushes.White, i*10, j*10, 10, 10);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, i*10, j*10, 10, 10);
                    }

                }
            for (int q = 0; q < 1000; q++)
            {
                s.Step();
                for (int i = 1; i < 90 - 1; i++)
                    for (int j = 1; j < 55 - 1; j++)
                    {
                        if (s.field[i, j])
                        {
                            g.FillRectangle(Brushes.White, i*10, j*10, 10, 10);
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Black, i*10, j*10, 10, 10);
                        }

                    }
            }
        }

    }


    public abstract class LifeJourney
    {
        public const int WIDTH = 90;
        public const int HEIGHT = 55;
        
        public string Name => GetType().Name;
        public abstract void Set(int i, int j, bool value);
        public abstract bool Get(int i, int j);
        public abstract void Step(); // makes one iteration. Performance-critical!
        public void Clear()
        {
            for (int i = 1; i < WIDTH - 1; i++)
                for (int j = 1; j < HEIGHT - 1; j++)
                    Set(i, j, false);
        }
        public void GenerateRandomField(int seed, double threshold)
        {
            Random rand = new Random(seed);
            for (int i = 1; i < WIDTH - 1; i++)
                for (int j = 1; j < HEIGHT - 1; j++)
                {
                    Set(i, j, rand.NextDouble() < threshold);

                }
        }
    }
    public class SimpleLife : LifeJourney
    {
        
        public bool[,] field = new bool[WIDTH, HEIGHT];
        public bool[,] temp = new bool[WIDTH, HEIGHT];
    
        
        public override bool Get(int i, int j) => field[i, j];

        public override void Set(int i, int j, bool value) => field[i, j] = value;
        public SimpleLife()
        {
            GenerateRandomField(322, 0.3);
        }
        public override void Step()
        {
            for (int i = 1; i < WIDTH - 1; i++)
            {
                for (int j = 1; j < HEIGHT - 1; j++)
                {  // первый проход: вычисляем будущее состоянее
                    bool isAlive = field[i, j];
                    
                    int numNeigbours = 0;
                    if (field[i - 1, j - 1]) numNeigbours++;
                    if (field[i - 1, j]) numNeigbours++;
                    if (field[i - 1, j + 1]) numNeigbours++;
                    if (field[i, j - 1]) numNeigbours++;
                    if (field[i, j + 1]) numNeigbours++;
                    if (field[i + 1, j - 1]) numNeigbours++;
                    if (field[i + 1, j]) numNeigbours++;
                    if (field[i + 1, j + 1]) numNeigbours++;
                    bool keepAlive = isAlive && (numNeigbours == 2 || numNeigbours == 3);
                    bool makeNewLive = !isAlive && numNeigbours == 3;
                    temp[i, j] = keepAlive | makeNewLive;
                }
            }

            for (int i = 1; i < WIDTH - 1; i++)
                for (int j = 1; j < HEIGHT - 1; j++)
                {
                    // второй проход: копируем вычисленное состояние в текущее
                    field[i, j] = temp[i, j];
                }
        }
    }
}


