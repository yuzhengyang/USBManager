using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USBManager.UI.Commons
{
    public static partial class R
    {
        public static class Files
        {
            public static string App = Application.ExecutablePath;
            public static string Settings = DirTool.Combine(Paths.App, "USBManagerServiceSettings.ini");
            public static string USBIds = DirTool.Combine(Paths.App, "USBIds.json");
        }
    }
}
