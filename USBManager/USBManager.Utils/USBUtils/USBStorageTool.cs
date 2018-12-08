using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.WindowsUtils.RegisterUtils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using USBManager.Models.USBDeviceModels;
using USBManager.Models.USBStorageModels;
using USBManager.Utils.APIUtils;

namespace USBManager.Utils.USBUtils
{
    public static class USBStorageTool
    {
        public static List<USBStorageModel> GetAll()
        {
            List<USBStorageModel> result = new List<USBStorageModel>();
            try
            {
                var idList = GetStorageID();
                if (Ls.Ok(idList))
                {
                    foreach (var id in idList)
                    {
                        var volumeList = GetVolumeID(id);
                        if (Ls.Ok(volumeList))
                        {
                            foreach (var volume in volumeList)
                            {
                                var storageList = GetStorage(id, volume);
                                if (Ls.Ok(storageList)) result.AddRange(storageList);
                            }
                        }
                    }
                }
            }
            catch { }
            return result;
        }
        public static List<USBStorageIDModel> GetStorageID()
        {
            List<USBStorageIDModel> result = null;
            try
            {
                RegistryKey usbsKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\USBSTOR\Enum", false);
                if (usbsKey != null)
                {
                    string[] usbs = usbsKey.GetValueNames();
                    if (Ls.Ok(usbs))
                    {
                        result = new List<USBStorageIDModel>();
                        foreach (var usb in usbs)
                        {
                            object valueObj = usbsKey.GetValue(usb);
                            string value = valueObj.ToString();
                            if (int.TryParse(usb, out int index) && value.Contains("USB"))
                                result.Add(USBStorageIDModel.String2Model(value));
                        }
                    }
                }
            }
            catch { }
            return result;
        }
        public static List<USBStorageVolumeModel> GetVolumeID(USBStorageIDModel model)
        {
            List<USBStorageVolumeModel> result = null;
            try
            {
                RegistryKey idsKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\STORAGE\Volume", false);
                if (idsKey != null)
                {
                    string[] volumes = idsKey.GetSubKeyNames();
                    if (Ls.Ok(volumes))
                    {
                        result = new List<USBStorageVolumeModel>();
                        string containerId = "", classGUID = "";
                        //查找 USBSTOR 标记的卷 中ID吻合的项
                        foreach (var v in volumes)
                        {
                            if (v.Contains("_USBSTOR#") && v.Contains(model.StorageID))
                            {
                                RegistryKey usbKey = idsKey.OpenSubKey(v);
                                string[] infos = usbKey.GetValueNames();
                                if (Ls.Ok(infos) && v.Length > 38)
                                {
                                    classGUID = usbKey.GetValue("ClassGUID").ToString();
                                    containerId = usbKey.GetValue("ContainerID").ToString();
                                    result.Add(new USBStorageVolumeModel()
                                    {
                                        VolumeID = v,
                                        ClassGUID = classGUID,
                                        ContainerID = containerId
                                    });
                                }
                            }
                        }
                        //带着 ContainerID 查看所有卷
                        if (Str.Ok(containerId, classGUID))
                        {
                            foreach (var v in volumes)
                            {
                                if (!v.Contains("_USBSTOR#") && !v.Contains(model.StorageID))
                                {
                                    RegistryKey usbKey = idsKey.OpenSubKey(v);
                                    string[] infos = usbKey.GetValueNames();
                                    if (Ls.Ok(infos) && v.Length > 38)
                                    {
                                        string _class_guid = usbKey.GetValue("ClassGUID").ToString();
                                        string _container_id = usbKey.GetValue("ContainerID").ToString();
                                        if (containerId == _container_id && classGUID == _class_guid &&
                                            !result.Any(x => x.VolumeID == v))
                                        {
                                            result.Add(new USBStorageVolumeModel()
                                            {
                                                VolumeID = v,
                                                ClassGUID = _class_guid,
                                                ContainerID = _container_id
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return result;
        }
        public static List<USBStorageModel> GetStorage(USBStorageIDModel idModel, USBStorageVolumeModel volumeModel)
        {
            List<USBStorageModel> result = null;
            try
            {
                RegistryKey mountKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\MountedDevices", false);
                if (mountKey != null)
                {
                    string[] mounts = mountKey.GetValueNames();
                    if (Ls.Ok(mounts))
                    {
                        result = new List<USBStorageModel>();
                        foreach (var mnt in mounts)
                        {
                            if (mnt.Contains("DosDevices"))
                            {
                                object valueObj = mountKey.GetValue(mnt);
                                string value = Encoding.Default.GetString((byte[])valueObj).Replace("\0", "");
                                if (value.Contains(volumeModel.VolumeID))
                                {
                                    result.Add(new USBStorageModel()
                                    {
                                        VID = idModel.VID,
                                        PID = idModel.PID,
                                        VolumeID = volumeModel.VolumeID,
                                        StorageID = idModel.StorageID,
                                        Symbol = mnt.Replace("\\DosDevices\\", ""),
                                    });
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            return result;
        }
        public static void Bind(ref List<USBDeviceModel> list)
        {
            var ids = GetStorageID();
            if (Ls.Ok(ids) && Ls.Ok(list))
            {
                foreach (var l in list)
                {
                    foreach (var i in ids)
                    {
                        if (l.VID.Contains(i.VID) && l.PID.Contains(i.PID))
                        {
                            l.IsStorage = true;
                        }
                    }
                }
            }

            var vols = GetAll();
            if (Ls.Ok(vols) && Ls.Ok(list))
            {
                foreach (var l in list)
                {
                    foreach (var v in vols)
                    {
                        if (l.VID.Contains(v.VID) && l.PID.Contains(v.PID))
                        {
                            l.Volume += v.Symbol + ",";
                        }
                    }
                }
            }
        }
        public static bool Eject(string[] volumes)
        {
            bool flag = true;
            if (Ls.Ok(volumes))
            {
                foreach (var item in volumes)
                {
                    if (Str.Ok(item)) flag = flag && Eject(item);
                }
            }
            return flag;
        }
        public static bool Ejects(string volumes)
        {
            if (Str.Ok(volumes))
            {
                return Eject(volumes.Split(','));
            }
            return false;
        }
        public static bool Eject(string drive)
        {
            try
            {
                DriveInfo Drive = new DriveInfo(drive);
                IntPtr handle = USBAPITool.USBEject(drive);
                return USBAPITool.Eject(handle);
            }
            catch { return false; }
        }
    }
}
