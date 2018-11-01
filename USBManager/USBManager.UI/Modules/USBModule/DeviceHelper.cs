using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System.Collections.Generic;
using USBManager.Models.USBDeviceModels;
using USBManager.UI.Commons;

namespace USBManager.UI.Modules.USBModule
{
    public static class DeviceHelper
    {
        /// <summary>
        /// 获取全部设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void GetAllDevice()
        {
            R.Tx.TcppClient.Write(new TcpDataModel() { Type = 20002000 });
        }
        /// <summary>
        /// 启用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void EnableDevice(List<USBDeviceModel> list)
        {
            R.Tx.TcppClient.Write(new TcpDataModel()
            {
                Type = 20003000,
                Data = Json.Object2Byte(list)
            });
        }
        /// <summary>
        /// 禁用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void DisableDevice(List<USBDeviceModel> list)
        {
            R.Tx.TcppClient.Write(new TcpDataModel()
            {
                Type = 20003001,
                Data = Json.Object2Byte(list)
            });
        }
    }
}
