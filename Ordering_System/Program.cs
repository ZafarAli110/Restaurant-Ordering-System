using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;  // Process class is present in System.Diagnostics; nameSpace

namespace Ordering_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// 1.we need to get the current process name
            //string strProcessName = Process.GetCurrentProcess().ProcessName;

            //// 2.check if the process name is existing in the current process
            //Process[] arrayProcess = Process.GetProcessesByName(strProcessName);
            //// 3.if the process already exists then exit
            //if (arrayProcess.Length > 1)
            //{
            //    MessageBox.Show("The program is already running");
            //}
            //// 4. else execute the below code
            //else
            
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            
        }
    }
}
