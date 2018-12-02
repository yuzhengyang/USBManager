using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.ProcessUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using USBManager.Models.USBDeviceModels;
using USBManager.Utils.Commons;
using USBManager.Utils.DevconUtils;

namespace USBManager.Utils.USBUtils
{
    public static class USBTool
    {
        /// <summary>
        /// 获取全部USB设备列表
        /// </summary>
        /// <returns></returns>
        public static List<USBDeviceModel> All()
        {
            var list1 = AllByFind();
            var list2 = AllByStatus();
            if (ListTool.HasElements(list1) && ListTool.HasElements(list2))
            {
                foreach (var x in list1)
                {
                    foreach (var y in list2)
                    {
                        if (x.ID == y.ID && x.Origin == y.Origin)
                        {
                            x.Running = y.Running;
                        }
                    }
                }
                USBStorageTool.Bind(ref list1);
                return list1;
            }
            if (ListTool.HasElements(list1))
            {
                USBStorageTool.Bind(ref list1);
                return list1;
            }

            USBStorageTool.Bind(ref list2);
            return list2;
        }
        /// <summary>
        /// 获取全部USB设备列表（根据FIND命令）
        /// </summary>
        /// <returns></returns>
        public static List<USBDeviceModel> AllByFind()
        {
            List<USBDeviceModel> list = null;
            List<string> temp = new List<string>();

            Process process = ProcessStarter.NewProcess(DevconExeSelector.GetExe(), " FIND USB*", R.Domain, R.Username, R.Password);
            ProcessTool.SleepKill(process, 5);
            ProcessStarter.Execute(process, new Action<string>((x) =>
            {
                temp.Add(x);
            }));

            if (ListTool.HasElements(temp))
            {
                string inline = string.Join("||||", temp);
                string[] inlines = inline.Split(new string[] { "USB\\" }, StringSplitOptions.RemoveEmptyEntries);
                if (ListTool.HasElements(inlines))
                {
                    list = new List<USBDeviceModel>();
                    foreach (var item in inlines)
                    {
                        var usb = USBDeviceModel.String2ModelByFind(item);
                        if (usb != null) list.Add(usb);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 获取全部USB设备列表（带状态，根据STATUS命令）
        /// </summary>
        /// <returns></returns>
        public static List<USBDeviceModel> AllByStatus()
        {
            List<USBDeviceModel> list = null;
            List<string> temp = new List<string>();

            Process process = ProcessStarter.NewProcess(DevconExeSelector.GetExe(), " STATUS USB*", R.Domain, R.Username, R.Password);
            ProcessTool.SleepKill(process, 5);
            ProcessStarter.Execute(process, new Action<string>((x) =>
            {
                temp.Add(x);
            }));

            if (ListTool.HasElements(temp))
            {
                string inline = string.Join("||||", temp);
                string[] inlines = inline.Split(new string[] { "USB\\" }, StringSplitOptions.RemoveEmptyEntries);
                if (ListTool.HasElements(inlines))
                {
                    list = new List<USBDeviceModel>();
                    foreach (var item in inlines)
                    {
                        var usb = USBDeviceModel.String2ModelByStatus(item);
                        if (usb != null) list.Add(usb);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 结束超时 Devcon 工具进程
        /// </summary>
        /// <param name="second">超时时间（单位：秒）</param>
        public static void Kills(int second = 5)
        {
            string file = DevconExeSelector.GetExe();
            string name = Path.GetFileNameWithoutExtension(file);
            Azylee.Core.ProcessUtils.ProcessTool.Kills(name, file, second);
        }
        /// <summary>
        /// 启用USB设备
        /// </summary>
        /// <returns></returns>
        public static bool Enable(string id)
        {
            List<string> temp = new List<string>();
            Process process = ProcessStarter.NewProcess(DevconExeSelector.GetExe(), $" ENABLE \"USB\\{id}\"", R.Domain, R.Username, R.Password);
            ProcessTool.SleepKill(process, 5);
            ProcessStarter.Execute(process, new Action<string>((x) =>
            {
                temp.Add(x);
            }));

            if (ListTool.HasElements(temp))
            {
                foreach (var item in temp)
                {
                    if (Str.Ok(item) &&
                        item.ToUpper().StartsWith($"USB\\{id}") &&
                        item.ToUpper().Contains("ENABLE"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 禁用USB设备
        /// </summary>
        /// <returns></returns>
        public static bool Disable(string id)
        {
            List<string> temp = new List<string>();
            Process process = ProcessStarter.NewProcess(DevconExeSelector.GetExe(), $" DISABLE \"USB\\{id}\"", R.Domain, R.Username, R.Password);
            ProcessTool.SleepKill(process, 5);
            ProcessStarter.Execute(process, new Action<string>((x) =>
            {
                temp.Add(x);
            }));
            if (ListTool.HasElements(temp))
            {
                foreach (var item in temp)
                {
                    if (Str.Ok(item) &&
                        item.ToUpper().StartsWith($"USB\\{id}") &&
                        item.ToUpper().Contains("DISABLED"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
