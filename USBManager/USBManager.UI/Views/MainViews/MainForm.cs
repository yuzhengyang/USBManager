using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.WindowsUtils.BrowserUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using USBManager.UI.Commons;
using USBManager.Models.USBDeviceModels;
using USBManager.UI.Modules.USBModule;
using USBManager.UI.Views.OperationViews;
using Azylee.YeahWeb.SocketUtils.TcpUtils;

namespace USBManager.UI.Views.MainViews
{
    public partial class MainForm : Form
    {
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        List<USBDeviceModel> list = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                R.Tx.TcppClient?.Disconnect();
                R.Tx.TcppClient = new TcppClient(R.Tx.TcppIP, R.Tx.TcppPort,
                    TcppReceiver.ReceiveMessage, TcppReceiver.OnConnect, TcppReceiver.OnDisconnect);
                R.Tx.TcppClient.Connect();

                Title();
            }
            catch { }
        }
        public void Title()
        {
            try
            {
                Invoke(new Action(() =>
                {
                    Text = $"{R.AppNameCH} [{R.Tx.TcppIP}]";
                }));
            }
            catch { }
        }

        #region 程序菜单

        private void 连接到另一台计算机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            R.FormMan.GetUnique<ConnectComputerForm>().Show();
            R.FormMan.GetUnique<ConnectComputerForm>().WindowState = FormWindowState.Normal;
            R.FormMan.GetUnique<ConnectComputerForm>().Activate();
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceHelper.GetAllDevice();
        }
        private void uSBIDWebSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = $"http://www.linux-usb.org/usb.ids";
            if (BrowserSelector.ModernBrowser(out string browser))
                try { Process.Start(browser, $"{url}"); } catch { }
            else
                try { Process.Start($"{url}"); } catch { }
        }
        #endregion

        #region USB设备列表（菜单）
        private void DGVUSBList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DGVUSBList.CurrentCell = DGVUSBList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void 启用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVUSBList.CurrentRow != null)
            {
                string id = DGVUSBList.CurrentRow.Cells["DGVUSBList_InstanceID"].Value.ToString();
                R.Toast.Show("启用 USB", DGVUSBList.CurrentRow.Index + " : " + id);
                DeviceHelper.EnableDevice(new List<USBDeviceModel>()
                {
                    new USBDeviceModel(){ID = id}
                });
            }
            DeviceHelper.GetAllDevice();
        }
        private void 禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVUSBList.CurrentRow != null)
            {
                string id = DGVUSBList.CurrentRow.Cells["DGVUSBList_InstanceID"].Value.ToString();
                R.Toast.Show("禁用 USB", DGVUSBList.CurrentRow.Index + " : " + id);
                DeviceHelper.DisableDevice(new List<USBDeviceModel>()
                {
                    new USBDeviceModel(){ID = id}
                });
            }
            DeviceHelper.GetAllDevice();
        }
        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeviceHelper.GetAllDevice();
        }
        #endregion

        #region UI-USB设备列表
        public void DGVUSBList_AddOrUpdate(List<USBDeviceModel> list)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    DGVUSBList.Rows.Clear();
                    if (Ls.Ok(list))
                    {
                        foreach (var item in list)
                        {
                            DGVUSBList.Rows.Add(item.Desc, item.VID, item.PID, item.ID, item.Running ? "运行" : "禁用", item.VendorName, item.ProductName, item.IsStorage ? "存储" : "-");
                        }
                    }
                }));
            }
            catch { }
        }
        #endregion 
    }
}
