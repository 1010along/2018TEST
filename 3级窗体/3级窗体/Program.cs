using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3级窗体
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 land = new Form1();        //先弹出窗体1

            if (land.ShowDialog() == DialogResult.OK)
            {

                Form2 land2 = new Form2();        //先弹出窗体1   
                if (land2.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form3());
                }
             }

            
        }
    }
}
