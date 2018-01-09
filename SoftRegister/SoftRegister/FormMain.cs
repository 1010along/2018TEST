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

namespace SoftRegister
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        FormMain MyFrom;//在主窗体（frmMain)中声明一个变量(MyFrom)  ++++ 我加的
        SoftReg softReg = new SoftReg();

        private void FormMain_Load(object sender, EventArgs e)
        {

            MyFrom = this;  //我加的
            //判断软件是否注册
            RegistryKey retkey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("MYkey").CreateSubKey("Register.INI");//打开注册表项
            foreach (string strRNum in retkey.GetSubKeyNames())//判断是否注册
            {
                if (strRNum == softReg.GetRNum())//判断注册码是否相同
                {
                    this.labRegInfo.Text = "此软件已注册！";
                    MyFrom.Text = "此软件已注册";//我加的
                    this.btnReg.Enabled = false;
                    return;
                }
            }
            this.labRegInfo.Text = "此软件尚未注册！";
            MyFrom.Text = "请注册";//我加的
            this.btnReg.Enabled = true;
            MessageBox.Show("您现在使用的是试用版，可以免费试用100次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Int32 tLong;    //已使用次数
            try
            
            {
                //获取软件的已经使用次数
                tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MYkey", "UseTimes", 0);
                MessageBox.Show("您已经使用了" + tLong + "次！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                //首次使用软件
                MessageBox.Show("欢迎新用户使用本软件！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MYkey", "UseTimes", 0, RegistryValueKind.DWord);
            }

            //判断是否可以继续试用  //获取软件已经使用次数
            tLong = (Int32)Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MYkey", "UseTimes", 0);
            if (tLong < 100)
            {
                int tTimes = tLong + 1; //计算软件本次是第几次使用
                Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\MYkey", "UseTimes", tTimes); //将软件使用次数写入注册表
            }
            else
            {
                DialogResult result = MessageBox.Show("试用次数已到！您是否需要注册？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    FormRegister.state = false; //设置软件状态为不可用
                    btnReg_Click(sender, e);    //打开注册窗口
                }
                else
                {
                    Application.Exit(); //退出应用程序
                }
            }

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            FormRegister frmRegister = new FormRegister();
            frmRegister.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
