using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TurGame
{
    public partial class Form1 : Form
    {
        Form2 bedR;
        Form3 bathR;
        public static bool[] item1 = new bool[12];
        public static bool[] item2 = new bool[12];

        string[] itemBedR = new string[12];
        string[] itemBathR = new string[12];
        public Form1()
        {
            InitializeComponent();
            backpack_label.Text = progressBar1.Value+"/24";
            itemBedR[0] = "Килимок";
            itemBedR[1] = "Спальний мішок";
            itemBedR[2] = "Тепла куртка"; 
            itemBedR[3] = "Шапка";
            itemBedR[4] = "Светр";
            itemBedR[5] = "Футболка";
            itemBedR[6] = "Штани";
            itemBedR[7] = "Шорти";
            itemBedR[8] = "Черевики";
            itemBedR[9] = "Кросівки";
            itemBedR[10] = "Білизна";
            itemBedR[11] = "Дощовик";

            itemBathR[0] = "Кепка";
            itemBathR[1] = "Шкарпетки";
            itemBathR[2] = "Кружка";
            itemBathR[3] = "Миска";
            itemBathR[4] = "Ложка";
            itemBathR[5] = "Ніж";
            itemBathR[6] = "Туалетний папір";
            itemBathR[7] = "Сірники";
            itemBathR[8] = "Мило";
            itemBathR[9] = "Зубна щітка";
            itemBathR[10] = "Зубна паста";
            itemBathR[11] = "Гребінець";       

            foreach (string a in itemBedR)
            {
                label1.Text += a+"\n";
            }
            foreach (string a in itemBathR)
            {
                label2.Text += a + "\n";
            }

        }
      
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            int temp = 0;
            foreach (bool a in item1)
            {
                if (a)
                {
                    temp++;
                }

            }
            foreach (bool a in item2)
            {
                if (a)
                {
                    temp++;
                }

            }
            progressBar1.Value = temp;
            backpack_label.Text = progressBar1.Value + "/24";

            for (int i = 0; i < 12; i++)
            {
                if (item1[i]) { itemBedR[i] = "✔"; }
            }
            label1.Text = null;

            foreach (string a in itemBedR)
            {
                label1.Text += a + "\n";
            }

            for (int i = 0; i < 12; i++)
            {
                if (item2[i]) { itemBathR[i] = "✔"; }
            }
            label2.Text = null;

            foreach (string a in itemBathR)
            {
                label2.Text += a + "\n";
            }
            win();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bedR == null || bedR.IsDisposed)
            {
                bedR = new Form2();
                bedR.Show();
            }
            else
            {
                bedR.Close();
                bedR = new Form2();
                bedR.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bathR == null || bathR.IsDisposed)
            {
                bathR = new Form3();
                bathR.Show();
            }
            else
            {
                bathR.Close();
                bathR = new Form3();
                bathR.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Гра побудована за принципом пошукового квесту. " +
                "Згідно слиску шукай речі у кімнатах. Коли ти клікаєшь на потрібну" +
                " річ лівою кнопкою миши, вона опиняється в тебе у руках. Для того, щоб покласти речі до рюкзаку, " +
                "скористайся спеціальною кнопкою. Після того, як речі розміщені в рюкзаку, в списку" +
                " вони будуть відмічені, як виконані. Гра закінчується, коли зібрані всі речі.", 
                "Правила гри",
                MessageBoxButton.OK, 
                MessageBoxImage.Information
                );
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxResult res = System.Windows.MessageBox.Show("Ви впевнені, що хочете вийти? \n" +
               "Поточний прогрес не буде збережений.", "", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                if (bedR == null || bedR.IsDisposed)
                { }
                else { bedR.Close(); }
                if (bathR == null || bathR.IsDisposed)
                { }
                else { bedR.Close(); }
            }
            else if (res == MessageBoxResult.No)
            { e.Cancel = true; }
        }

        private void win()
        {
            if(progressBar1.Value==24)
            {
                System.Windows.MessageBox.Show(
                    "Ти зібрав усі речі!\nДо зустрічі у поході!!!",
                    "Перемога!!!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
                if (bathR == null || bathR.IsDisposed)
                { }
                else
                { bathR.Close(); }
                if (bedR == null || bedR.IsDisposed)
                { }
                else
                { bedR.Close(); }
            }
        }
    }
}
