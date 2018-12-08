using Azylee.Core.IOUtils.DirUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using USBManager.Utils.Commons;

namespace USBManager.Utils.DevconUtils
{
    internal static class DevconExeSelector
    {
        internal static string Root = @"Devcon";

        internal static string GetExe()
        {
            bool Is64 = Environment.Is64BitOperatingSystem;
            string exe = Is64 ? WIN10.X64 : WIN10.X32;
            OSName system = OSInfoTool.Caption();
            switch (system)
            {
                case OSName.WindowsXP: exe = Is64 ? XP.X64 : XP.X32; break;
                case OSName.Windows7: exe = Is64 ? WIN7.X64 : WIN7.X32; break;
                case OSName.Windows8Or81: exe = Is64 ? WIN8.X64 : WIN8.X32; break;
                case OSName.Windows10: exe = Is64 ? WIN10.X64 : WIN10.X32; break;
            }
            string file = DirTool.Combine(AppDomain.CurrentDomain.BaseDirectory, Root, exe);
            return file;
        }

        protected static class XP
        {
            internal const string X32 = "Devcon_xpx32.exe";
            internal const string X64 = "Devcon_xpx64.exe";
        }
        protected static class WIN7
        {
            internal const string X32 = "Devcon_7x32.exe";
            internal const string X64 = "Devcon_7x64.exe";
        }
        protected static class WIN8
        {
            internal const string X32 = "Devcon_10x32.exe";
            internal const string X64 = "Devcon_10x64.exe";
        }
        protected static class WIN10
        {
            internal const string X32 = "Devcon_10x32.exe";
            internal const string X64 = "Devcon_10x64.exe";
        }
    }
}
