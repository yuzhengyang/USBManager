using Azylee.Jsons;
using System.Collections.Generic;
using USBManager.Models.USBDeviceModels;
using USBManager.Service.Commons;

namespace USBManager.Service.Modules.USBModule
{
    /// <summary>
    /// USB 设备插入、拔出动作事件
    /// </summary>
    public static class DeviceAct
    {
        /// <summary>
        /// USB 设备改变
        /// </summary>
        /// <param name="all"></param>
        /// <param name="insert"></param>
        /// <param name="remove"></param>
        public static void ChangeDevice(List<USBDeviceModel> all, List<USBDeviceModel> insert, List<USBDeviceModel> remove)
        {
            foreach (var host in R.Hosts)
                R.Tx.TcppServer.Write(host, 20001000,
                    Json.Object2Byte(new USBDeviceBagModel()
                    {
                        All = all,
                        Insert = insert,
                        Remove = remove
                    }));
        }
        /// <summary>
        /// 插入 USB 设备
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        public static void InsertDevice(List<USBDeviceModel> all, List<USBDeviceModel> part)
        {

        }
        /// <summary>
        /// 拔出 USB 设备
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        public static void RemoveDevice(List<USBDeviceModel> all, List<USBDeviceModel> part)
        {

        }
    }
}
