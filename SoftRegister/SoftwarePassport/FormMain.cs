using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwarePassport
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        SoftReg softReg = new SoftReg();

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string strHardware = this.txtHardware.Text;
                string strLicence = softReg.GetRNum(strHardware);
                this.txtLicence.Text = strLicence;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("输入的机器码格式错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
