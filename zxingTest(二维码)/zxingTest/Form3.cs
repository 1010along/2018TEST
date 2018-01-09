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
    public partial class Form3 : Form
    {
        BarcodeReader reader = null;
        public Form3()
        {
            
            InitializeComponent();
            reader = new BarcodeReader();
        }
        private void Form3_DragEnter(object sender, DragEventArgs e)//当拖放进入窗体  
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;    //显示拷贝效应  
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form3_DragDrop(object sender, DragEventArgs e) //当拖放放在窗体上  
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false); //获取文件名  
            if (fileNames.Length > 0)
            {
                pictureBoxPic.Load(fileNames[0]);   //显示图片  
                Result result = reader.Decode((Bitmap)pictureBoxPic.Image); //通过reader解码  
                textBoxText.Text = result.Text; //显示解析结果  
            }
        }

        
    }
}
