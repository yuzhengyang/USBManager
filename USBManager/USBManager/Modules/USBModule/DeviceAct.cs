using Azylee.Jsons;
using System.Collections.Generic;
using USBManager.Commons;
using USBManager.Models.USBDeviceModels;

namespace USBManager.Modules.USBModule
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
            R.MainUI.DGVUSBList_Refresh();
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
