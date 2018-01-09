using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace zxingTest
{
    public partial class Form1 : Form
    {
        EncodingOptions options = null;
        BarcodeWriter writer = null;
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = pictureBoxQr.Width,
                Height = pictureBoxQr.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
        }

        private void buttonQr_Click(object sender, EventArgs e)
        {
            if (textBoxText.Text == string.Empty)
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }
            Bitmap bitmap = writer.Write(textBoxText.Text);
            pictureBoxQr.Image = bitmap;
        }

       
        
        //测试用的，无作用
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null)
            {
                f2 = new Form2();
                f2.Show();  
            }
            else
                f2.Focus();
        }
    }
}
