using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using zxingTest;
using Excel = Microsoft.Office.Interop.Excel;
using SoftRegister;
namespace ExcelAddIn1
{
   
    public partial class Ribbon1
    {
        
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.ShowDialog();
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            FormMain fm4 = new FormMain();
            fm4.ShowDialog();
        }

        private void gallery1_ItemsLoading(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
