using Azylee.Jsons;
using System.Collections.Generic;
using USBManager.Models.USBStorageModels;
using USBManager.Service.Commons;

namespace USBManager.Service.Modules.USBModule
{
    public static class StorageAct
    {
        /// <summary>
        /// USB 设备改变
        /// </summary>
        /// <param name="all"></param>
        /// <param name="insert"></param>
        /// <param name="remove"></param>
        public static void ChangeDevice(List<USBStorageModel> all, List<USBStorageModel> insert, List<USBStorageModel> remove)
        {
            foreach (var host in R.Hosts)
                R.Tx.TcppServer.Write(host, 30001000,
                    Json.Object2Byte(new USBStorageBagModel()
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
        public static void InsertDevice(List<USBStorageModel> all, List<USBStorageModel> part)
        {

        }
        /// <summary>
        /// 拔出 USB 设备
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        public static void RemoveDevice(List<USBStorageModel> all, List<USBStorageModel> part)
        {

        }
    }
}
