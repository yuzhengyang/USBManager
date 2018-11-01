using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.ThreadUtils.SleepUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBManager.Models.USBDeviceModels;
using USBManager.Utils.DevconUtils;
using USBManager.Utils.USBUtils;

namespace USBManager.Utils.ListenerUtils
{
    /// <summary>
    /// USB 设备监听
    /// </summary>
    public class USBListener
    {
        #region 字段
        private bool HasEvent = false;
        private CancellationTokenSource Token = new CancellationTokenSource();
        private ManagementEventWatcher InsertEvent = null, RemoveEvent = null;
        private List<USBDeviceModel> __AllDevice = null, __InsertDevice = null, __RemoveDevice = null;
        private DateTime __RefreshTime = DateTime.MinValue, __ChangeTime = DateTime.MinValue,
            __InsertTime = DateTime.MinValue, __RemoveTime = DateTime.MinValue;
        #endregion

        #region 属性
        /// <summary>
        /// 全部USB设备列表
        /// </summary>
        public List<USBDeviceModel> AllDevice { get { return __AllDevice; } }
        /// <summary>
        /// 新插入USB设备列表
        /// </summary>
        public List<USBDeviceModel> InsertDevice { get { return __InsertDevice; } }
        /// <summary>
        /// 移除的USB设备列表
        /// </summary>
        public List<USBDeviceModel> RemoveDevice { get { return __RemoveDevice; } }
        public string RefreshTime { get { return DateTimeConvert.StandardString(__RefreshTime); } }
        public string ChangeTime { get { return DateTimeConvert.StandardString(__ChangeTime); } }
        public string InsertTime { get { return DateTimeConvert.StandardString(__InsertTime); } }
        public string RemoveTime { get { return DateTimeConvert.StandardString(__RemoveTime); } }
        #endregion

        #region 事件处理委托
        /// <summary>
        /// USB设备处理
        /// </summary>
        /// <param name="all"></param>
        /// <param name="part"></param>
        public delegate void USBHandler(List<USBDeviceModel> all, List<USBDeviceModel> part);
        public delegate void USBChangeHandler(List<USBDeviceModel> all, List<USBDeviceModel> insert, List<USBDeviceModel> remove);
        public USBHandler USBInsertEvent, USBRemoveEvent;
        public USBChangeHandler USBChangeEvent;
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="insert"></param>
        /// <param name="remove"></param>
        public USBListener(USBChangeHandler change, USBHandler insert, USBHandler remove)
        {
            try
            {
                ManagementScope Scope = new ManagementScope("root\\CIMV2");
                Scope.Options.EnablePrivileges = true;

                // USB插入监视  
                WqlEventQuery InsertQuery = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 5), "TargetInstance isa 'Win32_USBControllerDevice'");
                InsertEvent = new ManagementEventWatcher(Scope, InsertQuery);
                InsertEvent.EventArrived += _USBInsert;
                InsertEvent.Start();

                // USB拔出监视  
                WqlEventQuery RemoveQuery = new WqlEventQuery("__InstanceDeletionEvent", new TimeSpan(0, 0, 5), "TargetInstance isa 'Win32_USBControllerDevice'");
                RemoveEvent = new ManagementEventWatcher(Scope, RemoveQuery);
                RemoveEvent.EventArrived += _USBRemove;
                RemoveEvent.Start();

                USBInsertEvent += insert;
                USBRemoveEvent += remove;
                USBChangeEvent += change;
            }
            catch { }
        }


        /// <summary>
        /// 启动USB监控
        /// </summary>
        /// <param name="action">操作USB设备的动作</param>
        public void Start()
        {
            WatcherTask();
        }
        /// <summary>
        /// 监控任务
        /// </summary>
        public void WatcherTask()
        {
            USBDictionary.Get();
            Task.Factory.StartNew(() =>
            {
                Refresh();//第一次运行初始化USB列表
                while (!Token.IsCancellationRequested)
                {
                    if (HasEvent)
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
                        HasEvent = false;
                    }
                    Sleep.S(1);
                }
            });
        }
        /// <summary>  
        /// 停止USB设备监控
        /// </summary>  
        public void Stop()
        {
            InsertEvent?.Stop();
            InsertEvent = null;

            RemoveEvent?.Stop();
            RemoveEvent = null;

            USBInsertEvent = null;
            USBRemoveEvent = null;

            Token.Cancel();
        }

        #region 系统 USB 设备变动消息
        /// <summary>
        /// 系统消息拦截（可增强USB的识别敏感度）
        /// </summary>
        public void SystemMessage(ref Message message)
        {
            try
            {
                const int WM_DEVICECHANGE = 0x219; //设备变动（插入/移除）
                const int WM_DEVICEARRVIAL = 0x8000; //设备插入
                const int WM_DEVICEMOVECOMPLETE = 0x8004; //设备移除
                if (message.Msg == WM_DEVICECHANGE)
                {
                    switch (message.WParam.ToInt32())
                    {
                        // 设备插入
                        case WM_DEVICEARRVIAL: HasEvent = true; break;
                        // 设备移除
                        case WM_DEVICEMOVECOMPLETE: HasEvent = true; break;
                    }
                }
            }
            catch { }
        }
        private void _USBInsert(Object sender, EventArrivedEventArgs e)
        {
            try
            {
                if (e.NewEvent.ClassPath.ClassName == "__InstanceCreationEvent") HasEvent = true;
            }
            catch { }
        }
        private void _USBRemove(Object sender, EventArrivedEventArgs e)
        {
            try
            {
                if (e.NewEvent.ClassPath.ClassName == "__InstanceDeletionEvent") HasEvent = true;
            }
            catch { }
        }
        #endregion

        /// <summary>
        /// 刷新 USB 设备列表信息
        /// </summary>
        public void Refresh()
        {
            if ((DateTime.Now - __RefreshTime).TotalSeconds > 1)
            {
                __InsertDevice = new List<USBDeviceModel>();
                __RemoveDevice = new List<USBDeviceModel>();

                var temp = USBTool.All().OrderBy(x => x.VID).OrderBy(x => x.PID).ToList();
                USBDictionary.Bind(ref temp);
                USBStorageTool.Bind(ref temp);
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
        public static List<USBDeviceModel> Except(List<USBDeviceModel> all, List<USBDeviceModel> part)
        {
            List<USBDeviceModel> rs = null;
            if (all != null && part != null)
            {
                rs = new List<USBDeviceModel>(all);//深复制
                for (int i = rs.Count - 1; i >= 0; i--)
                {
                    foreach (var item in part)
                    {
                        if (rs[i].Origin == item.Origin)
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
