using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System.Collections.Generic;
using System.Linq;
using USBManager.Models.USBDeviceModels;
using USBManager.UI.Commons;

namespace USBManager.UI.Modules.USBModule
{
    public static class DeviceFun
    {
        /// <summary>
        /// 设备改变通知
        /// </summary>
        /// <param name="host"></param>
        public static void Change(TcpDataModel model)
        {
            USBDeviceBagModel device = Json.Byte2Object<USBDeviceBagModel>(model.Data);
            R.MainUI.DGVUSBList_AddOrUpdate(device.All);
        }

        /// <summary>
        /// 获取全部设备列表
        /// </summary>
        /// <param name="host"></param>
        public static void GetAllDevice(TcpDataModel model)
        {
            List<USBDeviceModel> list = Json.Byte2Object<List<USBDeviceModel>>(model.Data);
            R.MainUI.DGVUSBList_AddOrUpdate(list);
        }

        /// <summary>
        /// 启用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Enable(TcpDataModel model)
        {
            List<USBDeviceModel> list = Json.Byte2Object<List<USBDeviceModel>>(model.Data);
            if (Ls.Ok(list))
            {
                int count = list.Count(x => x.Running == true);
                R.Toast.Show("启用设备", $"已启用{count}个设备");
            }
        }

        /// <summary>
        /// 禁用设备列表
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void Disable(TcpDataModel model)
        {
            List<USBDeviceModel> list = Json.Byte2Object<List<USBDeviceModel>>(model.Data);
            if (Ls.Ok(list))
            {
                int count = list.Count(x => x.Running == false);
                R.Toast.Show("启用设备", $"已禁用{count}个设备");
            }
        }
    }
}
