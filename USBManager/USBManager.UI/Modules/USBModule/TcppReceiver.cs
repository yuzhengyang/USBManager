using Azylee.Jsons;
using Azylee.YeahWeb.SocketUtils.TcpUtils;
using USBManager.UI.Commons;

namespace USBManager.UI.Modules.USBModule
{
    public static class TcppReceiver
    {
        /// <summary>
        /// 已连接
        /// </summary>
        /// <param name="host"></param>
        public static void OnConnect(string host)
        {
            R.Tx.TcppClient.Write(new TcpDataModel()
            {
                Type = 10001000,
                Data = Json.Object2Byte(R.ConnectKey)
            });
        }
        /// <summary>
        /// 已断开
        /// </summary>
        /// <param name="host"></param>
        public static void OnDisconnect(string host)
        {
        }
        /// <summary>
        /// 接受消息
        /// </summary>
        /// <param name="host"></param>
        /// <param name="model"></param>
        public static void ReceiveMessage(string host, TcpDataModel model)
        {
            switch (model.Type)
            {
                case 10001000:
                    DeviceHelper.GetAllDevice();
                    break; //认证连接成功

                #region USB Device 设备指令（2000----）
                //通知
                case 20001000: DeviceFun.Change(model); break; //设备改变
                //信息
                case 20002000: DeviceFun.GetAllDevice(model); break; //全部设备信息
                //控制
                case 20003000: DeviceFun.Enable(model); break; //启用设备
                case 20003001: DeviceFun.Disable(model); break; //禁用设备
                #endregion

                //========================================
                //========================================
                //========================================

                #region USB Storage 磁盘指令（3000----）
                //通知
                case 30001000: break; //通知：插入设备
                case 30001001: break; //通知：移除设备
                //状态
                case 30002000: break; //状态：USB列表更新时间
                //信息
                case 30003000: break; //信息：全部USB列表
                case 30003001: break; //信息：插入USB列表
                case 30003002: break; //信息：移除USB列表
                //控制
                case 30004000: break; //控制：启用设备
                case 30004001: break; //控制：禁用设备
                #endregion

                default: break;
            }
        }
    }
}
