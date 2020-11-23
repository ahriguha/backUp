using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;
using Telegram.Bot.Types;
using System.Security.Cryptography;
using System.Threading;



namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw;
        //ProcessStartInfo cmd;
        static Telegram.Bot.TelegramBotClient Bot;
        static int offset = 0;
        bool sended;
        public Form1()
        {
            InitializeComponent();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWork;
            if (this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync("1240255286:AAErv1IVn_lwaK_xXegFkiFKpGawWmPosMU");
            }
        }
        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String;

            Bot = new TelegramBotClient(key);
            await Bot.SetWebhookAsync(""); while (true)
            {
                var updates = await Bot.GetUpdatesAsync(offset); // получаем массив обновлений

                foreach (var update in updates) // Перебираем все обновления
                {
                    var message = update.Message;
                    //try
                    //{
                    if (message != null)
                    {
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            Console.WriteLine(message.From);
                            Console.WriteLine(message.Text);
                            string s = Console.ReadLine();
                            await Bot.SendTextMessageAsync(message.Chat.Id, s);
                            offset = update.Id + 1;
                        }                       
                    }
                    //}
                    //catch { }
                }
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sended = true;
        }
    }
}
