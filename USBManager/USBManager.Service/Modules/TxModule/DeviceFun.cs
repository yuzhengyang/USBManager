using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System.Collections.Generic;
using USBManager.Models.USBDeviceModels;
using USBManager.Service.Commons;
using USBManager.Utils.DevconUtils;
using USBManager.Utils.USBUtils;

namespace USBManager.Service.Modules.TxModule
{
    public static class DeviceFun
    {
        /// <summary>
        /// 获取所有USB设备
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void AllDevice(string host)
        {
            R.USBListener.Refresh();
            R.Tx.TcppServer.Write(host, 20002000, Json.Object2Byte(R.USBListener.AllDevice));
        }
        /// <summary>
        /// 启用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Enable(string host, TcpDataModel model)
        {
            List<USBDeviceModel> list = Json.Byte2Object<List<USBDeviceModel>>(model.Data);
            if (Ls.Ok(list))
            {
                foreach (var item in list)
                {
                    if (USBTool.Enable(item.ID))
                        item.Running = true;
                }
            }
            R.Tx.TcppServer.Write(host, 20003000, Json.Object2Byte(list));
        }
        /// <summary>
        /// 禁用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Disable(string host, TcpDataModel model)
        {
            List<USBDeviceModel> list = Json.Byte2Object<List<USBDeviceModel>>(model.Data);
            if (Ls.Ok(list))
            {
                foreach (var item in list)
                {
                    if (USBTool.Disable(item.ID))
                        item.Running = false;
                }
            }
            R.Tx.TcppServer.Write(host, 20003001, Json.Object2Byte(list));
        }
    }
}
