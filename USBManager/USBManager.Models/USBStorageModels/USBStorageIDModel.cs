using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBStorageModels
{
    public class USBStorageIDModel
    {
        public string VID { get; set; }
        public string PID { get; set; }
        public string StorageID { get; set; }
        public static USBStorageIDModel String2Model(string s)
        {
            USBStorageIDModel model = null;
            try
            {
                string[] lines = s.Split('\\');
                if (Ls.Ok(lines) && lines.Count() >= 3)
                {
                    string _ids = lines[1];
                    string _volid = lines[2];
                    string[] _ids_lines = _ids.Split('&');
                    if (Ls.Ok(_ids_lines) && _ids_lines.Count() >= 2)
                    {
                        model = new USBStorageIDModel();
                        model.VID = _ids_lines[0];
                        model.PID = _ids_lines[1];
                        model.StorageID = _volid;
                    }
                }
            }
            catch { }
            return model;
        }
    }
}
