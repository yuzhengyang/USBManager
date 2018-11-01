using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBStorageModels
{
    /// <summary>
    /// USB 磁盘模型
    /// </summary>
    public class USBStorageModel
    {
        /// <summary>
        /// 盘符
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// VID
        /// </summary>
        public string VID { get; set; }
        /// <summary>
        /// PID
        /// </summary>
        public string PID { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        public string VendorName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        public string VolumeID { get; set; }
        public string StorageID { get; set; }
    }
}
