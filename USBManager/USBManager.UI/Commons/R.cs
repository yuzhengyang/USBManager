using Azylee.Core.AppUtils;
using Azylee.Core.FormUtils;
using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Core.VersionUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI;
using System;
using System.Reflection;
using System.Windows.Forms;
using USBManager.UI.Views.MainViews;

namespace USBManager.UI.Commons
{
    public static partial class R
    {
        internal static string AppName = "USBManager.Service.201810191502";
        internal static string AppNameCH = "USB 管理界面 -OnlyUI";
        internal static string AppNameCHShort = "USB 管理界面";
        internal static string AppId = "";
        internal static DateTime StartTime = DateTime.Now;//程序启动时间
        internal static DateTime PowerTime = ComputerInfoTool.StartTime();//系统启动时间（存在误差，同systeminfo）
        internal static long RunningTime = 0;//程序运行时长
        internal static long RunTimes = 0;//程序运行次数
        internal static string MachineName = Environment.MachineName;
        internal static Module Module = Assembly.GetExecutingAssembly().GetModules()[0];
        internal static string DbConnString = "DefaultConnection";//默认数据库连接字符
        internal static string AesKey = "ljpljp";//默认加密字符密钥
        internal static string ConnectKey = "USBManager.Service.201810191502.tcpp";//Tcp通信连接认证密钥

        internal static bool IsAdministrator = PermissionTool.IsAdministrator();

        internal static MainForm MainUI;
        internal static Version Version = VersionTool.Format(Application.ProductVersion);
        internal static FormManTool FormMan = new FormManTool();//窗体管理器
        internal static long AppSize = 0;//App占用空间情况


        internal static IPLocationModel IPLocation = null;
        internal static string UserName = ComputerInfoTool.UserName();
        internal static string EnvironmentUserName = ComputerInfoTool.UserName();
        internal static string UserDomainName = ComputerInfoTool.UserDomainName();

        internal static Log Log = new Log(LogLevel.All, LogLevel.All);

    }
}
