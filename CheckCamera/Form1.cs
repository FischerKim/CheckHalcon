using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace CheckCamera
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int PostMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")]
        private static extern IntPtr FindWindow(string className, string caption);
        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr parent, IntPtr startChild, string className, string caption);


        public Form1()
        {
            InitializeComponent();
            System.Diagnostics.Process.Start(@"C:\MELSEC\MNETG\UTL\MnetgUtl.exe");
            //CC IE Control Utility(Board).exe 실행
            System.Threading.Thread.Sleep(1000);
            System.Diagnostics.Process.Start(@"C:\MELSEC\Common\UTL\DvMonutl.exe");
            //Device Monitor Utility(Board).exe 실행
            System.Threading.Thread.Sleep(1000);
            string StrFile = "";
            string StrWindowName = "";           
            using (var reader = new StreamReader(@"C:\Users\Administrator\Desktop\name.csv"))
            {
                StrFile = reader.ReadLine().ToString();
                StrWindowName = reader.ReadLine().ToString();
            }
            
            Process p = new Process();
            p.StartInfo.FileName = StrFile;
            p.StartInfo.UseShellExecute = true;
            p.Start();

            //  System.Diagnostics.Process.Start(@"C:\Program Files\GingaPP\bin\LongTestCode(AN).hdev");
            //");
            //LongTestCode(AN) - 바로 가기.exe 실행, F5 key press
            System.Threading.Thread.Sleep(5000);
            IntPtr d = FindWindow(null, StrWindowName);
            //C:/Program Files/GingaPP/bin/LongTestCode(AN).hdev - MVTec HALCON HDevelop 20.11 Steady Deep Learning
            //   d = FindWindowEx(d, IntPtr.Zero, "hdevelop", null);
            PostMessage(d, 0x100, new IntPtr(0x74), IntPtr.Zero);//WM_KEYDOWN = 0x100  VK_F5 = 0x74
            PostMessage(d, 0x101, new IntPtr(0x74), new IntPtr(1 << 31));//WM_KEYUP = 0x101
                                                                         //001C0970

            //https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
            // Process[] processes = Process.GetProcessesByName("hdevelop");

            //
            //p.Kill();
        }


    }
}
