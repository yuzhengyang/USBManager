using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.WindowsUtils.BrowserUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using USBManager.Commons;
using USBManager.Models.USBDeviceModels;
using USBManager.Utils.USBUtils;

namespace USBManager.Views.MainViews
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
            R.USBListener.Start();
            DGVUSBList_Refresh();
        }

        #region 程序菜单
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGVUSBList_Refresh();
        }

        private void 技术中心网站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = $"https://github.com/yuzhengyang/USBManager";
            if (BrowserSelector.ModernBrowser(out string browser))
                try { Process.Start(browser, $"{url}"); } catch { }
            else
                try { Process.Start($"{url}"); } catch { }
        }
        private void 关于USBManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = $"https://github.com/yuzhengyang/USBManager";
            if (BrowserSelector.ModernBrowser(out string browser))
                try { Process.Start(browser, $"{url}"); } catch { }
            else
                try { Process.Start($"{url}"); } catch { }
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
                if (USBTool.Enable(id)) DGVUSBList_Refresh();
            }
        }
        private void 禁用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGVUSBList.CurrentRow != null)
            {
                string id = DGVUSBList.CurrentRow.Cells["DGVUSBList_InstanceID"].Value.ToString();
                R.Toast.Show("禁用 USB", DGVUSBList.CurrentRow.Index + " : " + id);
                if (USBTool.Disable(id)) DGVUSBList_Refresh();
            }
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DGVUSBList_Refresh();
        }
        #endregion

        #region UI-USB设备列表
        public void DGVUSBList_Refresh()
        {
            try
            {
                R.USBListener.Refresh();

                Invoke(new Action(() =>
                {
                    DGVUSBList.Rows.Clear();
                    if (Ls.Ok(R.USBListener.AllDevice))
                    {
                        foreach (var item in R.USBListener.AllDevice)
                        {
                            DGVUSBList.Rows.Add(item.Desc, item.VID, item.PID, item.ID, item.Running ? "运行" : "禁用", item.VendorName, item.ProductName, item.IsStorage ? "存储" : "-",item.Volume);
                        }
                    }
                }));
            }
            catch { }
        }
        #endregion

    }
}
