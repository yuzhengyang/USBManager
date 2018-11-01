using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBDeviceModels
{
    public class USBDeviceBagModel
    {
        public List<USBDeviceModel> All { get; set; }
        public List<USBDeviceModel> Insert { get; set; }
        public List<USBDeviceModel> Remove { get; set; }
    }
}
