using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USBManager.Models.USBStorageModels;
using USBManager.Service.Commons;
using USBManager.Service.Modules.USBModule;

namespace USBManager.Service.Modules.TxModule
{
    public static class StorageFun
    {
        /// <summary>
        /// 获取所有USB设备
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void AllDevice(string host)
        {
            R.USBStorageListener.Refresh();
            R.Tx.TcppServer.Write(host, 30002000, Json.Object2Byte(R.USBStorageListener.AllDevice));
        }
        /// <summary>
        /// 启用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Enable(string host, TcpDataModel model)
        {
            List<USBStorageModel> list = Json.Byte2Object<List<USBStorageModel>>(model.Data);
            if (Ls.Ok(list))
            {
                foreach (var item in list)
                {
                    //if (DevconUSBTool.Enable(item.ID))
                    //    item.Running = true;
                }
            }
            R.Tx.TcppServer.Write(host, 30003000, Json.Object2Byte(list));
        }
        /// <summary>
        /// 禁用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Disable(string host, TcpDataModel model)
        {
            List<USBStorageModel> list = Json.Byte2Object<List<USBStorageModel>>(model.Data);
            if (Ls.Ok(list))
            {
                foreach (var item in list)
                {
                    //if (DevconUSBTool.Disable(item.ID))
                    //    item.Running = false;
                }
            }
            R.Tx.TcppServer.Write(host, 30003001, Json.Object2Byte(list));
        }
    }
}
