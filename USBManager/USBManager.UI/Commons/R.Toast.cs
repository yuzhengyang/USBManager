using Azylee.WinformSkin.FormUI.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USBManager.UI.Commons
{
    public static partial class R
    {
        public static class Toast
        {
            /// <summary>
            /// 显示弹框
            /// </summary>
            /// <param name="title">标题</param>
            /// <param name="text">内容</param>
            /// <param name="type">类型</param>
            /// <param name="second">显示秒数</param>
            /// <param name="clickAction">点击事件</param>
            public static void Show(string title, string text,
                ToastForm.ToastType type = ToastForm.ToastType.info,
                short second = 5, Action clickAction = null)
            {
                try
                {
                    MainUI.Invoke(new Action(() =>
                    {
                        ToastForm.Display(title, text, ToastForm.ToastType.info, clickAction, second);
                    }));
                }
                catch { }
            }
        }
    }
}
