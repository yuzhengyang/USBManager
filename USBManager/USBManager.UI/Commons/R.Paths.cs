using Azylee.Core.IOUtils.DirUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.UI.Commons
{
    public static partial class R
    {
        public static class Paths
        {
            public static string App = AppDomain.CurrentDomain.BaseDirectory;
            public static string Root = DirTool.Parent(App);
            public static string Data = DirTool.Combine(Root, "Data\\");
            public static string Temp = DirTool.Combine(Root, "Temp\\");

            public static Dictionary<string, string> Relative = new Dictionary<string, string>()
            {
                { "|AppRoot|",Root},
            };

            // 基础路径
            public static string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            // @".\Plugin\OSSpeed\OSSpeed.exe" 
            public static string OSSpeedPath = BasePath + @"Plugin\OSSpeed\OSSpeed.exe";
            // @".\Plugin\CommonSoft\CommonSoft.exe" 
            public static string CommonSoft = BasePath + @".\Plugin\CommonSoft\CommonSoft.exe";
            // @".\Plugin\RubbishCleaner\RubbishCleaner.exe"
            public static string RubbishCleaner = BasePath + @"Plugin\RubbishCleaner\RubbishCleaner.exe";
            // @".\AutoUpdate.exe"
            public static string AutoUpdate = BasePath + @"AutoUpdate.exe";
        }
    }
}
