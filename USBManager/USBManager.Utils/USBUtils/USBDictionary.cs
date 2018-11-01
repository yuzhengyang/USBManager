using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.IOUtils.TxtUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USBManager.Models.USBIDModels;
using USBManager.Utils.Commons;
using System;
using USBManager.Models.USBDeviceModels;
using USBManager.Models.USBStorageModels;

namespace USBManager.Utils.USBUtils
{
    public static class USBDictionary
    {
        internal static List<USBVendorModel> __USBIDS;
        internal static List<USBVendorModel> USBIDS { get { return __USBIDS; } }
        internal static void Get()
        {
            Task.Factory.StartNew(() =>
            {
                List<USBVendorModel> list = GetByFile();
                if (Ls.Ok(list)) __USBIDS = list;

                List<USBVendorModel> weblist = GetByWeb();
                if (Ls.Ok(weblist))
                {
                    __USBIDS = weblist;
                    TxtTool.Create(R.Files.USBIds, Json.Object2String(weblist));
                }
            });
        }
        internal static List<USBVendorModel> GetByWeb()
        {
            try
            {
                string s = HttpTool.Get("http://www.linux-usb.org/usb.ids");
                string[] lines = s.Split('\n');
                if (Ls.Ok(lines))
                {
                    List<USBVendorModel> list = new List<USBVendorModel>();
                    List<string> vendor_lines = new List<string>();

                    foreach (var l in lines)
                    {
                        if (l.StartsWith("#")) continue;
                        if (!Str.Ok(l.Trim())) continue;

                        if (!l.StartsWith("\t") && vendor_lines.Count() > 0)
                        {
                            var model = USBVendorModel.String2Model(vendor_lines);
                            if (model != null)
                            {
                                list.Add(model);
                                if (model.VendorID == "FFEE") break;
                                vendor_lines = new List<string>();
                            }
                        }

                        vendor_lines.Add(l);
                    }

                    if (Ls.Ok(list)) return list;
                }
            }
            catch { }
            return null;
        }
        internal static List<USBVendorModel> GetByFile()
        {
            string s = TxtTool.Read(R.Files.USBIds);
            List<USBVendorModel> list = Json.String2Object<List<USBVendorModel>>(s);
            if (Ls.Ok(list)) return list;
            return null;
        }
        internal static void Bind(ref List<USBDeviceModel> list)
        {
            if (Ls.Ok(list) && Ls.Ok(__USBIDS))
            {
                foreach (var item in list)
                {
                    string vid = item.VID.Substring(4, 4);
                    string pid = item.PID.Substring(4, 4);
                    //查询厂商信息
                    var vendor = __USBIDS.FirstOrDefault(x => x.VendorID == vid);
                    if (vendor != null)
                    {
                        item.VendorName = vendor.VendorName;//设置厂商信息
                        if (Ls.Ok(vendor.USBProducts))
                        {
                            //查询产品信息
                            var product = vendor.USBProducts.FirstOrDefault(x => x.ProductID.Contains(pid));
                            if (product != null) item.ProductName = product.ProductName;//设置产品信息
                        }
                    }
                }
            }
        }
        internal static void Bind(ref List<USBStorageModel> list)
        {
            if (Ls.Ok(list) && Ls.Ok(__USBIDS))
            {
                foreach (var item in list)
                {
                    string vid = item.VID.Substring(4, 4);
                    string pid = item.PID.Substring(4, 4);
                    //查询厂商信息
                    var vendor = __USBIDS.FirstOrDefault(x => x.VendorID == vid);
                    if (vendor != null)
                    {
                        item.VendorName = vendor.VendorName;//设置厂商信息
                        if (Ls.Ok(vendor.USBProducts))
                        {
                            //查询产品信息
                            var product = vendor.USBProducts.FirstOrDefault(x => x.ProductID.Contains(pid));
                            if (product != null) item.ProductName = product.ProductName;//设置产品信息
                        }
                    }
                }
            }
        }
    }
}
