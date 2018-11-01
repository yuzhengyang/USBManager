using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBStorageModels
{
    public class USBStorageVolumeModel
    {
        public string ClassGUID { get; set; }
        public string ContainerID { get; set; }
        public string  VolumeID { get; set; }
    }
}
