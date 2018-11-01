using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using USBManager.Models.USBStorageModels;
using USBManager.Utils.USBUtils;

namespace USBManager.Utils.ListenerUtils
{
    public class USBStorageListener
    {
        #region 字段
        private CancellationTokenSource Token = new CancellationTokenSource();
        private List<USBStorageModel> __AllDevice = null, __InsertDevice = null, __RemoveDevice = null;
        private DateTime __RefreshTime = DateTime.MinValue, __ChangeTime = DateTime.MinValue,
            __InsertTime = DateTime.MinValue, __RemoveTime = DateTime.MinValue;
        #endregion

        #region 属性
        /// <summary>
        /// 全部USB设备列表
        /// </summary>
        public List<USBStorageModel> AllDevice { get { return __AllDevice; } }
        /// <summary>
        /// 新插入USB设备列表
        /// </summary>
        public List<USBStorageModel> InsertDevice { get { return __InsertDevice; } }
        /// <summary>
        /// 移除的USB设备列表
        /// </summary>
        public List<USBStorageModel> RemoveDevice { get { return __RemoveDevice; } }
        public string RefreshTime { get { return DateTimeConvert.StandardString(__RefreshTime); } }
        public string ChangeTime { get { return DateTimeConvert.StandardString(__ChangeTime); } }
        public string InsertTime { get { return DateTimeConvert.StandardString(__InsertTime); } }
        public string RemoveTime { get { return DateTimeConvert.StandardString(__RemoveTime); } }
        #endregion

        #region 事件处理委托
        /// <summary>
        /// USB磁盘处理
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        public delegate void USBHandler(List<USBStorageModel> all, List<USBStorageModel> part);
        public delegate void USBChangeHandler(List<USBStorageModel> all, List<USBStorageModel> insert, List<USBStorageModel> remove);
        public USBHandler USBInsertEvent, USBRemoveEvent;
        public USBChangeHandler USBChangeEvent;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="insert"></param>
        /// <param name="remove"></param>
        public USBStorageListener(USBChangeHandler change, USBHandler insert, USBHandler remove)
        {
            USBInsertEvent += insert;
            USBRemoveEvent += remove;
            USBChangeEvent += change;
        }

        public void Start() { ListenerTask(); }
        private void ListenerTask()
        {
            Task.Factory.StartNew(() =>
            {
                while (!Token.IsCancellationRequested)
                {
                    try
                    {
                        Refresh();

                        //USB设备发生改变触发事件
                        if (Ls.Ok(InsertDevice) || Ls.Ok(RemoveDevice))
                        {
                            USBChangeEvent?.Invoke(AllDevice, InsertDevice, RemoveDevice);
                            __ChangeTime = DateTime.Now;
                        }

                        //对插入事件做处理
                        if (ListTool.HasElements(InsertDevice))
                        {
                            USBInsertEvent?.Invoke(AllDevice, InsertDevice);
                            __InsertTime = DateTime.Now;
                        }

                        //对移除设备事件做处理
                        if (ListTool.HasElements(RemoveDevice))
                        {
                            USBRemoveEvent?.Invoke(AllDevice, RemoveDevice);
                            __RemoveTime = DateTime.Now;
                        }
                    }
                    catch { }
                    Sleep.S(1);
                }
            });
        }

        /// <summary>
        /// 刷新 USB 磁盘列表信息
        /// </summary>
        public void Refresh()
        {
            if ((DateTime.Now - __RefreshTime).TotalSeconds > 1)
            {
                __InsertDevice = new List<USBStorageModel>();
                __RemoveDevice = new List<USBStorageModel>();

                var temp = USBStorageTool.GetAll();
                USBDictionary.Bind(ref temp);
                if (__AllDevice != null)
                {
                    //对比插入的设备列表
                    __InsertDevice = Except(temp, __AllDevice);
                    //对比移除的设备列表
                    __RemoveDevice = Except(__AllDevice, temp);
                }
                //更新当前最新USB列表
                __AllDevice = temp;

                __RefreshTime = DateTime.Now;
            }
        }
        /// <summary>
        /// 求差集（获取新增设备或移除设备）
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        public static List<USBStorageModel> Except(List<USBStorageModel> all, List<USBStorageModel> part)
        {
            List<USBStorageModel> rs = null;
            if (all != null && part != null)
            {
                rs = new List<USBStorageModel>(all);//深复制
                for (int i = rs.Count - 1; i >= 0; i--)
                {
                    foreach (var item in part)
                    {
                        if (rs[i].VID == item.VID && rs[i].PID == item.PID)
                        {
                            rs.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            return rs;
        }
    }
}
