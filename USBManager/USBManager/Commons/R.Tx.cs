using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USBManager.Modules.USBModule;

namespace USBManager.Commons
{
    public static partial class R
    {
        public static class Tx
        {
            internal static string TcppIP = "127.0.0.1";
            internal static int TcppPort = 52810;
            internal static TcppClient TcppClient = null;
        }
    }
}
