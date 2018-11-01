using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USBManager.Models.USBIDModels
{
    public class USBVendorModel
    {
        public string VendorID { get; set; }
        public string VendorName { get; set; }
        public List<USBProductModel> USBProducts { get; set; }
        public static USBVendorModel String2Model(List<string> list)
        {
            USBVendorModel model = null;
            if (Ls.Ok(list))
            {
                model = new USBVendorModel();
                foreach (var line in list)
                {
                    if (!line.StartsWith("\t"))
                    {
                        string vid = line.Substring(0, 4).Trim().ToUpper();
                        string vname = line.Substring(4).Trim();

                        model.VendorID = vid;
                        model.VendorName = vname;
                    }
                    else
                    {
                        string pid = line.Trim().Substring(0, 4).Trim().ToUpper();
                        string pname = line.Trim().Substring(4).Trim();
                        if (model.USBProducts == null)
                            model.USBProducts = new List<USBProductModel>();

                        model.USBProducts.Add(
                            new USBProductModel()
                            {
                                ProductID = pid,
                                ProductName = pname
                            });
                    }
                }
            }
            return model;
        }
    }
}
