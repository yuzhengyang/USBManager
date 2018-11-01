using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.TxtUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USBManager.Service.Commons;
using USBManager.Service.Views.MainViews;
using USBManager.Utils.USBUtils;

namespace USBManager.Service
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

            InitSettings();

            R.MainUI = new MainForm();
            Application.Run(R.MainUI);
        }

        static void InitSettings()
        {
            R.Switch.ShowNotifyIcon = IniTool.GetBool(R.Files.Settings, "Switch", "ShowNotifyIcon", true);
            R.Switch.ShowToast = IniTool.GetBool(R.Files.Settings, "Switch", "ShowToast", true);
        }
    }
}
