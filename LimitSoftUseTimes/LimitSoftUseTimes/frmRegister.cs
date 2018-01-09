using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimitSoftUseTimes
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            textBox1.Text = Softreg.GetRNum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")//判断是否输入了注册码
            {
                MessageBox.Show("注册码输入不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox2.Text.Equals(Softreg.GetRNum()))//判断注册码是否正确
                {
                    RegistryKey retkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("software", true).CreateSubKey("mrwxk").CreateSubKey("mrwxk.ini").CreateSubKey(textBox2.Text);//打开注册表项，并创建一个子项
                    retkey.SetValue("UserName", "mrsoft");//为新创建的注册表项设置值
                    MessageBox.Show("注册成功,程序需要重新加载！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();//隐藏当前窗体
                    frmMain frmmain = new frmMain();//实例化主窗体对象
                    frmmain.Show();//显示主窗体
                }
                else
                {
                    MessageBox.Show("注册码输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
