using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.UI.Commons
{
    public static partial class R
    {
        public static class Switch
        {
            internal static bool USBBeep = true;
            internal static bool Restart = false;//是否重启程序
            internal static bool IsDevMode = false;//是否处于开发人员模式
            internal static bool ICanWriteFile = false;//是否可以写出文件（检测权限）
            internal static bool IsRelease = true;
            internal static bool UpdateFormIsOpen = false;
        }
    }
}
