using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBStorageModels
{
    public class USBStorageBagModel
    {
        public List<USBStorageModel> All { get; set; }
        public List<USBStorageModel> Insert { get; set; }
        public List<USBStorageModel> Remove { get; set; }
    }
}
