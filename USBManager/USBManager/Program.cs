using Azylee.Core.AppUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USBManager.Commons;
using USBManager.Views.MainViews;

namespace USBManager
{
    static class Program
    {
        static AppUnique AppUnique = new AppUnique();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //解决进程互斥
            if (!AppUnique.IsUnique(R.AppName)) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            R.MainUI = new MainForm();
            Application.Run(R.MainUI);
        }
    }
}
