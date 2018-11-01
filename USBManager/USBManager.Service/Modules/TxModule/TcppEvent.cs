using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Jsons;
using Azylee.WinformSkin.FormUI.Toast;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USBManager.Service.Commons;
using USBManager.Service.Modules.USBModule;

namespace USBManager.Service.Modules.TxModule
{
    public static class TcppEvent
    {
        /// <summary>
        /// 已连接
        /// </summary>
        /// <param name="host"></param>
        public static void OnConnect(string host)
        {
            R.Toast.Show("已连接", host, ToastForm.ToastType.warn);
        }
        /// <summary>
        /// 已断开
        /// </summary>
        /// <param name="host"></param>
        public static void OnDisconnect(string host)
        {
            if (R.Hosts.Contains(host))
                R.Hosts.Remove(host);

            R.Toast.Show("已断开", host, ToastForm.ToastType.error);
            R.MainUI.NIMainText();
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void ReceiveMessage(string host, TcpDataModel model)
        {
            if (model == null) return;

            if (R.Hosts.Contains(host))
            {
                switch (model.Type)
                {
                    #region USB Device 设备指令（2000----）
                    //通知
                    case 20001000: break; //设备改变
                    //信息
                    case 20002000: DeviceFun.AllDevice(host); break; //全部设备信息
                    //控制
                    case 20003000: DeviceFun.Enable(host, model); break; //启用设备
                    case 20003001: DeviceFun.Disable(host, model); break; //禁用设备
                    #endregion

                    //========================================
                    //========================================
                    //========================================

                    #region USB Storage 磁盘指令（3000----）
                    //通知
                    case 30001000: break; //设备改变
                    //信息
                    case 30002000: StorageFun.AllDevice(host); break; //全部设备信息
                    //控制
                    case 30003000: StorageFun.Enable(host, model); break; //启用设备
                    case 30003001: StorageFun.Disable(host, model); break; //禁用设备
                    #endregion

                    default: break;
                }
            }
            else
            {
                if (model.Type == 10001000) Authentication(host, model);
            }
        }

        /// <summary>
        /// 身份认证
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Authentication(string host, TcpDataModel model)
        {
            string key = Json.Byte2Object<string>(model.Data);
            if (key == R.ConnectKey)
            {
                if (!R.Hosts.Contains(host))
                {
                    R.Hosts.Add(host);
                    R.Toast.Show("认证通过", host, ToastForm.ToastType.info);
                    R.MainUI.NIMainText();

                    R.Tx.TcppServer.Write(host, 10001000, key);
                }
            }
        }
    }
}
