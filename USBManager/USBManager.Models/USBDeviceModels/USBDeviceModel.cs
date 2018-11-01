using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBDeviceModels
{
    /// <summary>
    /// USB 设备模型
    /// </summary>
    public class USBDeviceModel
    {

        /// <summary>
        /// 设备描述
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 正常启用中
        /// </summary>
        public bool Running { get; set; }
        /// <summary>
        /// 完整ID
        /// </summary>
        public string ID { get; set; }
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
        /// <summary>
        /// 原始数据
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// 是USB存储设备
        /// </summary>
        public bool IsStorage { get; set; }
        /// <summary>
        /// 磁盘驱动器号
        /// </summary>
        public string  Volume { get; set; }

        #region 数据转换
        /// <summary>
        /// 从字符串转换模型（Find）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static USBDeviceModel String2ModelByFind(string s)
        {
            string nameFlag = ":";
            USBDeviceModel model = null;
            try
            {
                if (Str.Ok(s) && s.ToUpper().StartsWith("VID_"))
                {
                    string upper = s.ToUpper();
                    string[] parts = upper.Split(new string[] { "||||", "    ", "\t", "DEVICE IS DISABLED.", "DRIVER IS RUNNING." },
                        StringSplitOptions.RemoveEmptyEntries);
                    if (ListTool.HasElements(parts))
                    {
                        string vid = "";
                        string pid = "";
                        string name = "";
                        string origin = "";
                        if (parts.Length > 0 && parts[0].StartsWith("VID_"))
                        {
                            origin = "USB\\" + parts[0];
                            int vidA = 0, vidB = 0, pidA = 0, pidB = 0;
                            vidA = parts[0].IndexOf("VID");
                            if (vidA >= 0) vidB = parts[0].IndexOf("&", vidA);
                            if (vidB >= 0) pidA = parts[0].IndexOf("PID");
                            if (pidA >= 0) pidB = parts[0].IndexOf("\\", pidA);
                            if (vidA >= 0 && vidB > 0 && pidA > 0 && pidB > 0)
                            {
                                vid = parts[0].Substring(vidA, vidB - vidA);
                                pid = parts[0].Substring(pidA, pidB - pidA);
                            }
                        }
                        if (parts.Length > 1)
                        {
                            int nameA = 0;
                            nameA = parts[1].IndexOf(nameFlag);
                            if (nameA >= 0) name = parts[1].Substring(nameA + nameFlag.Length);
                        }

                        if (Str.Ok(vid) && Str.Ok(pid))
                        {
                            model = new USBDeviceModel();
                            model.VID = vid.Trim();
                            model.PID = pid.Trim();
                            model.ID = $"{vid}&{pid}";
                            model.Origin = origin.Trim();
                            model.Desc = Str.Ok(name.Trim()) ? name.Trim() : "USB";
                        }
                    }
                }
            }
            catch { }
            return model;
        }
        /// <summary>
        /// 从字符串转换模型（Status）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static USBDeviceModel String2ModelByStatus(string s)
        {
            string nameFlag = "NAME:";
            USBDeviceModel model = null;
            try
            {
                if (Str.Ok(s) && s.ToUpper().StartsWith("VID_"))
                {
                    string upper = s.ToUpper();
                    bool running = false;
                    if (upper.Contains("DRIVER IS RUNNING.")) running = true;
                    string[] parts = upper.Split(new string[] { "||||", "    ", "\t", "DEVICE IS DISABLED.", "DRIVER IS RUNNING." },
                        StringSplitOptions.RemoveEmptyEntries);
                    if (ListTool.HasElements(parts))
                    {
                        string origin = "";
                        string vid = "";
                        string pid = "";
                        string name = "";
                        if (parts.Length > 0 && parts[0].StartsWith("VID_"))
                        {
                            origin = "USB\\" + parts[0];
                            int vidA = 0, vidB = 0, pidA = 0, pidB = 0;
                            vidA = parts[0].IndexOf("VID");
                            if (vidA >= 0) vidB = parts[0].IndexOf("&", vidA);
                            if (vidB >= 0) pidA = parts[0].IndexOf("PID");
                            if (pidA >= 0) pidB = parts[0].IndexOf("\\", pidA);
                            if (vidA >= 0 && vidB > 0 && pidA > 0 && pidB > 0)
                            {
                                vid = parts[0].Substring(vidA, vidB - vidA);
                                pid = parts[0].Substring(pidA, pidB - pidA);
                            }
                        }
                        if (parts.Length > 1)
                        {
                            int nameA = 0;
                            nameA = parts[1].IndexOf(nameFlag);
                            if (nameA >= 0) name = parts[1].Substring(nameA + nameFlag.Length);
                        }

                        if (Str.Ok(vid) && Str.Ok(pid))
                        {
                            model = new USBDeviceModel();
                            model.VID = vid.Trim();
                            model.PID = pid.Trim();
                            model.ID = $"{vid}&{pid}";
                            model.Origin = origin.Trim();
                            model.Desc = Str.Ok(name.Trim()) ? name.Trim() : "USB";
                            model.Running = running;
                        }
                    }
                }
            }
            catch { }
            return model;
        }
        #endregion
    }
}
