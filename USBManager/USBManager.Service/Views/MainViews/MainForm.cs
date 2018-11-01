using Azylee.Core.AppUtils;
using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using Azylee.Core.WindowsUtils.CMDUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBManager.Service.Commons;
using USBManager.Service.Modules.TxModule;

namespace USBManager.Service.Views.MainViews
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 窗口事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!R.Switch.ShowNotifyIcon) NIMain.Visible = false;
            NIMainText();
            HideForm();

            Do();

            if (PermissionTool.IsAdmin()) Text = $"{Text} [管理员]";
            else Text = $"{Text} [权限不足：部分功能受限]";
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideForm();
            switch (e.CloseReason)
            {
                case CloseReason.None:
                    e.Cancel = true;
                    R.Log.W("AccessSecurity::关闭事件:阻止：闭包的原因未定义，或者无法确定。");
                    break;
                case CloseReason.WindowsShutDown:
                    R.Log.W("AccessSecurity::关闭事件：允许：操作系统正在关机之前关闭所有应用程序。");
                    break;
                case CloseReason.MdiFormClosing:
                    e.Cancel = true;
                    R.Log.W("AccessSecurity::关闭事件:阻止：正在关闭此多文档界面 (MDI) 窗体的父窗体。");
                    break;
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    R.Log.W("AccessSecurity::关闭事件:阻止：用户是通过关闭窗体用户界面 (UI)，例如通过单击 关闭 窗体的窗口上的按钮选择 关闭 从窗口的控制菜单，或按 ALT + F4。");
                    break;
                case CloseReason.TaskManagerClosing:
                    e.Cancel = true;
                    R.Log.W("AccessSecurity::关闭事件:阻止：Microsoft Windows 任务管理器正在关闭该应用程序。");
                    break;
                case CloseReason.FormOwnerClosing:
                    e.Cancel = true;
                    R.Log.W("AccessSecurity::关闭事件:阻止：所有者窗体正在关闭。");
                    break;
                case CloseReason.ApplicationExitCall:
                    R.Log.W("AccessSecurity::关闭事件:允许：System.Windows.Forms.Application.Exit 方法 System.Windows.Forms.Application 类调用。");
                    break;
            }
        }
        #endregion
        #region Function
        private void Do()
        {
            Task.Factory.StartNew(() =>
            {
                List<int> ports = CMDNetstatTool.GetAvailablePorts(10, 52810);
                if (Ls.Ok(ports))
                {
                    foreach (var p in ports)
                    {
                        try
                        {
                            R.Tx.TcppPort = p;
                            R.Tx.TcppServer = new TcppServer(R.Tx.TcppPort, TcppEvent.ReceiveMessage,
                                TcppEvent.OnConnect, TcppEvent.OnDisconnect);
                            R.Tx.TcppServer.Start();//启动 Socket Tcp 通信机制
                            IniTool.Set(R.Files.Settings, "Tx", "TcppPort", R.Tx.TcppPort);
                            IniTool.Set(R.Files.Settings, "Tx", "StartTime", DateTime.Now.ToString());
                            break;
                        }
                        catch { }
                    }
                }

                R.USBListener.Start();// 启动USB监控
                R.USBStorageListener.Start();// 启动U盘监控
            });
        }
        #endregion
        #region 菜单栏

        #endregion

        #region 右下角图标（菜单）
        public void NIMainText()
        {
            if (Ls.Ok(R.Hosts))
                NIMain.Text = R.AppNameCHShort + $" [{R.Hosts.Count()}C]";
            else
                NIMain.Text = R.AppNameCHShort;
        }
        private void NIMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
        private void 主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }
        #endregion

        #region 系统消息拦截
        protected override void WndProc(ref Message message)
        {
            R.USBListener.SystemMessage(ref message);
            base.WndProc(ref message);
        }
        #endregion

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        private void HideForm()
        {
            Opacity = 0;
            ShowInTaskbar = false;
            Hide();
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        private void ShowForm()
        {
            Opacity = 100;
            ShowInTaskbar = true;
            if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;
            Show();
            Activate();
        }
        private void Exit()
        {
            R.Tx.TcppServer.Stop();//停止通信
            R.USBListener.Stop();//停止USB监听

            //隐藏窗口图标
            try { Invoke(new Action(() => { NIMain.Visible = false; })); } catch { }

            //正常退出
            try { Invoke(new Action(() => { Application.Exit(); })); } catch { }

            //退出及强制退出（无法正常退出时的应急方法）
            Task.Factory.StartNew(() =>
            {
                //延迟结束进程
                Sleep.S(1);
                Azylee.Core.ProcessUtils.ProcessTool.SleepKill(Process.GetCurrentProcess(), 3);

                //强制退出
                Sleep.S(2);
                try { Environment.Exit(Environment.ExitCode); } catch { }
            });
        }

    }
}
