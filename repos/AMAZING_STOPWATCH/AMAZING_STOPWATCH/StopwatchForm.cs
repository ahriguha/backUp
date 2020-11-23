using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMAZING_STOPWATCH
{
    public partial class StopwatchForm : Form
    {
        WordStopWatch wsw;
        public StopwatchForm()
        {
            InitializeComponent();
            wsw = new WordStopWatch();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            wsw.Start();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = wsw.tick().Hours.ToString() +":"+ wsw.tick().Minutes.ToString() +":"+wsw.tick().Seconds.ToString()+"."+wsw.tick().Milliseconds.ToString();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            wsw.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            wsw.Stop();
            timer1.Stop();
            wsw.Reset();
            label1.Text = "0:0:0.000";
        }


        private class WordStopWatch : Stopwatch
        {
            // Temporary save start-time and end-time
            public DateTime StartAt { get; private set; }
            public DateTime EndAt { get; private set; }

            // Save your records


            // Override Start() to save StartAt
            public void Start()
            {
                StartAt = DateTime.Now;
                base.Start();
            }

            public TimeSpan tick()
            {
                EndAt = DateTime.Now;
                StartAt = EndAt - base.Elapsed;
                return EndAt - StartAt;
            }

            // Override Stop() to save EndAt and your records.
            public void Stop()
            {                
                base.Stop();                              
            }
        }
    }

}
