using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;//需要引用System.Management.dll
using System.Text;
using System.Threading.Tasks;

namespace LimitSoftUseTimes
{
    class Softreg
    {

         ///<summary>
        /// 获取CPU序列号
        ///</summary>
        ///<returns></returns>
        public string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");//获取系统CPU处理器
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();//获取CPU序列号
                break;
            }
            return strCpu;
        }
        // 取得设备硬盘的序列号
        public string GetDiskVolumeSerialNumber()
        {
            //获取系统硬盘
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();//返回硬盘序列号
        }
        //生成机器码
        public string GetMNum()
        {
            string strNum = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string strMNum = strNum.Substring(0, 24);//从生成的字符串中取出前24个字符做为机器码
            return strMNum;//返回生成的机器码
        }
        public int[] intCode = new int[127];//存储密钥
        public int[] intNumber = new int[25];//存机器码的Ascii值
        public char[] Charcode = new char[25];//存储机器码字
        public void setIntCode()//给数组赋值小于10的数
        {
            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i % 9;
            }
        }

        //获得CPU的序列号
        //getMNum方法中用到getCpu和GetDiskVolumeSerialNumber两个自定义方法，其中getCpu方法用来获取本机CPU序列号，GetDiskVolumeSerialNumber方法用来获取本机硬盘序列号，它们的实现代码如下：


        //生成注册码
        public string GetRNum()
        {
            setIntCode();//初始化127位数组

            for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
            {
                Charcode[i] = Convert.ToChar(this.GetMNum().Substring(i - 1, 1));
            }
            for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
            {
                intNumber[j] = intCode[Convert.ToInt32(Charcode[j])] + Convert.ToInt32(Charcode[j]);
            }
            string strAsciiName = "";//用于存储注册码
            for (int j = 1; j < intNumber.Length; j++)
            {
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
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                    }
                    else
                    {
                        strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                    }
                }
            }
            return strAsciiName;//返回生成的注册码
        }


    }
}
