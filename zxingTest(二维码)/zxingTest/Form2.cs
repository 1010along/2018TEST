using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
namespace zxingTest
{
    public partial class Form2 : Form
    {
        EncodingOptions options = null;
        BarcodeWriter writer = null;
        public Form2()

        {
           
                InitializeComponent();
                options = new EncodingOptions
                {
                    //DisableECI = true,  
                    //CharacterSet = "UTF-8",  
                    Width = pictureBox1.Width,
                    Height = pictureBox1.Height
                };
                writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.ITF;
                writer.Options = options;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }
            //如下面的代码
            string strs = textBox1.Text;
            int len = strs.Length;
            if (len != 10)
            {
                MessageBox.Show("输入内容必须为10个字符的数字！");
                return;
            }
            //判断字符串的长度，使用字符串自带的属性 Length
            Bitmap bitmap2 = writer.Write(textBox1.Text);
            pictureBox1.Image = bitmap2;
        }
    }
}
