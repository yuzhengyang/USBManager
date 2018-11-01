using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Core.ProcessUtils;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USBManager.UI.Commons;
using USBManager.UI.Modules.USBModule;

namespace USBManager.UI.Views.OperationViews
{
    public partial class ConnectComputerForm : Form
    {
        public ConnectComputerForm()
        {
            InitializeComponent();
        }

        private void ConnectComputerForm_Load(object sender, EventArgs e)
        {
            TBIP.Text = R.Tx.TcppIP;
            TBPort.Text = R.Tx.TcppPort.ToString();
        }

        private void BTConnect_Click(object sender, EventArgs e)
        {
            if (RBLocal.Checked)
            {
                int port = IniTool.GetInt(R.Files.Settings, "Tx", "TcppPort", 0);
                if (port > 0)
                {
                    Connect("127.0.0.1", port);
                    Close();
                }
            }
            else if (RBRemote.Checked)
            {
                if (Str.Ok(TBIP.Text, TBPort.Text) && int.TryParse(TBPort.Text, out int port))
                {
                    Connect(TBIP.Text, port);
                    Close();
                }
            }
        }
        #region Function
        private void ConnectLocalByProcess()
        {
            try
            {
                Process[] process = Process.GetProcessesByName("USBManager.Service");
                if (Ls.Ok(process))
                {
                    string file = process[0].MainModule.FileName;
                    if (File.Exists(file))
                    {
                        string path = DirTool.Parent(file);
                        string set_file = DirTool.Combine(path, "USBManagerServiceSettings.ini");
                        int port = IniTool.GetInt(set_file, "Tx", "TcppPort", 0);
                        if (port > 0)
                        {
                            Connect("127.0.0.1", port);
                            Close();
                        }
                    }
                }
            }
            catch { }
        }
        private void Connect(string ip, int port)
        {
            R.Tx.TcppIP = ip;
            R.Tx.TcppPort = port;

            R.Tx.TcppClient?.Disconnect();
            R.Tx.TcppClient = new TcppClient(R.Tx.TcppIP, R.Tx.TcppPort,
                TcppReceiver.ReceiveMessage, TcppReceiver.OnConnect, TcppReceiver.OnDisconnect);
            R.Tx.TcppClient.Connect();
            R.MainUI.Title();
        }
        #endregion
        private void RBLocal_CheckedChanged(object sender, EventArgs e)
        {
            TBIP.Enabled = false;
            TBPort.Enabled = false;
            RBLocal.ForeColor = Color.Black;
            RBRemote.ForeColor = Color.Gray;
        }

        private void RBRemote_CheckedChanged(object sender, EventArgs e)
        {
            TBIP.Enabled = true;
            TBPort.Enabled = true;
            RBLocal.ForeColor = Color.Gray;
            RBRemote.ForeColor = Color.Black;
        }
    }
}
