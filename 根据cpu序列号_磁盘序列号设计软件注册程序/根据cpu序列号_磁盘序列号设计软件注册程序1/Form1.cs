using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
namespace 根据cpu序列号_磁盘序列号设计软件注册程序1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 取得设备硬盘的卷标号
        public string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //获得CPU的序列号
        public string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }
        //生成机器码
        private void button1_Click(object sender, EventArgs e)
        {

            label2.Text = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string[] strid = new string[24];//
            for (int i = 0; i < 24; i++)//把字符赋给数组
            {
                strid[i] = label2.Text.Substring(i, 1);
            }
            label2.Text = "";
            Random rdid = new Random();
            for (int i = 0; i < 24; i++)//从数组随机抽取24个字符组成新的字符生成机器三
            {
                label2.Text += strid[rdid.Next(0, 24)];
            }
            
        }

        public int[] intCode = new int[127];//用于存密钥
        public void setIntCode()//给数组赋值个小于10的随机数
        {
            Random ra = new Random();
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = ra.Next(0, 9);
            }
        }
        public int[] intNumber = new int[25];//用于存机器码的Ascii值
        public char[] Charcode = new char[25];//存储机器码字
                                             
        //生成注册码
        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                //把机器码存入数组中
                setIntCode();//初始化127位数组
                for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
                {
                    Charcode[i] = Convert.ToChar(label2.Text.Substring(i - 1, 1));
                }//
                for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
                {
                    intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);

                }
                string strAsciiName = null;//用于存储机器码
                for (int j = 1; j < intNumber.Length; j++)
                {
                    //MessageBox.Show((Convert.ToChar(intNumber[j])).ToString());
                    if (intNumber[j] >= 48 && intNumber[j] <= 57)//判断字符ASCII值是否0－9之间
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else if (intNumber[j] >= 65 && intNumber[j] <= 90)//判断字符ASCII值是否A－Z之间
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else if (intNumber[j] >= 97 && intNumber[j] <= 122)//判断字符ASCII值是否a－z之间
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else//判断字符ASCII值不在以上范围内
                    {
                        if (intNumber[j] > 122)//判断字符ASCII值是否大于z
                        { strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString(); }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                        }

                    }
                    label3.Text = strAsciiName;//得到注册码
                    label1.Text = strAsciiName;//得到注册码
                }
            }
            else
            { MessageBox.Show("请选生成机器码", "注册提示"); }
        }
        //注册
        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                if (textBox1.Text.TrimEnd().Equals(label3.Text.TrimEnd()))
                {

                    Microsoft.Win32.RegistryKey retkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software", true).CreateSubKey("ZHY").CreateSubKey("ZHY.INI").CreateSubKey(textBox1.Text.TrimEnd());
                    retkey.SetValue("UserName", "科技");
                    MessageBox.Show("注册成功");
                }
                else
                {
                    MessageBox.Show("注册码输入错误");

                }

            }
            else { MessageBox.Show("请生成注册码", "注册提示"); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //复制：
        private void button5_Click(object sender, EventArgs e)
        {
            // Takes the selected text from a text box and puts it on the clipboard.
            if (label3.Text != "")
                Clipboard.SetDataObject(label3.Text);
        }
        //粘贴：
        private void button6_Click(object sender, EventArgs e)
        {
            // Declares an IDataObject to hold the data returned from the clipboard.
            // Retrieves the data from the clipboard.
            IDataObject iData = Clipboard.GetDataObject();

            // Determines whether the data is in a format you can use.
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // Yes it is, so display it in a text box.
                textBox1.Text = (String)iData.GetData(DataFormats.Text);
            }
        }
        //退出
        private void button7_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
                Clipboard.SetDataObject(label1.Text);
        }
    }
}
