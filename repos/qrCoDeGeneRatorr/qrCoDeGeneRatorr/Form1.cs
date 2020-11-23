using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QRCoder;
using static QRCoder.PayloadGenerator;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing.Imaging;

namespace qrCoDeGeneRatorr
{
    public partial class Form1 : Form
    {
        Bitmap qrImage;
       
        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;               
                var gen = new QRCodeGenerator();
                //Girocode generator = new Girocode("DE33100205000001194700", "BFSWDE33BER", "Wikimedia", 1337.99m);
                var codeData = gen.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.M);
                QRCode qr = new QRCode(codeData);
                qrImage = qr.GetGraphic(5);
                pictureBox1.Size = qrImage.Size;
                if (qrImage.Width > 450)
                    this.Size = (System.Drawing.Size)new System.Drawing.Point(this.Width+(qrImage.Width-450), this.Height+(qrImage.Height-450));
                pictureBox1.Image = qrImage;
                button2.Enabled = true;
            }
            catch{ System.Windows.Forms.MessageBox.Show("Creating Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "QRlink.png";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    qrImage.Save(saveDialog.FileName, ImageFormat.Png);
                }
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Saving Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

    }
}