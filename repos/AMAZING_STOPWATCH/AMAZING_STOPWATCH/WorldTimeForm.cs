using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMAZING_STOPWATCH
{
    public partial class WorldTimeForm : Form
    {
        public WorldTimeForm()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void WorldTimeForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
