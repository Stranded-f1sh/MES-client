using System;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class BaoGongService
    {
        private JToken PostProductDevice(LoginInfo loginInfo, Device deviceObject)
        {
            JObject jObject = DeviceBaoGongApi.PostProductDevicesApi(loginInfo, deviceObject);
            return MyJsonConverter.GetJToken(jObject);
        }


        /// <summary>
        /// 设备报工接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="imei"></param>
        /// <param name="processId"></param>
        /// <param name="updateTime"></param>
        /// <returns></returns>
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, ProcessNameEnum processId, String updateTime)
        {
            Device device = new Device
            {
                Imei = imei,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = (int)processId,
                UserId = loginInfo.userId,
                Passed = (int)PassJudge.Qualified
            };
            if (updateTime != String.Empty)
            {
                device.EndTime = updateTime;
            }
            return PostProductDevice(loginInfo, device);
        }
        
        
        /**
         * 需要传不合格原因
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, ProcessNameEnum processId, 
            int reasonId, string reasonContext, String updateTime)
        {
            Device device = new Device
            {
                Imei = imei,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = (int)processId,
                UserId = loginInfo.userId,
                Passed = (int)PassJudge.Unqualified,
                ReasonId = reasonId,
                ReasonContext = reasonContext
            };
            if (updateTime != String.Empty)
            {
                device.EndTime = updateTime;
            }
            return PostProductDevice(loginInfo, device);
        }
        
        
        /**
         * 需要传工单号
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, int orderId, ProcessNameEnum processId, String updateTime)
        {
            Device device = new Device
            {
                Imei = imei,
                OrderId = orderId,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = (int)processId,
                UserId = loginInfo.userId,
                Passed = (int)PassJudge.Qualified,
            };
            if (updateTime != String.Empty)
            {
                device.EndTime = updateTime;
            }
            return PostProductDevice(loginInfo, device);
        }

        
        /**
         * 需要传工单号 和 不合格原因
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, int orderId, ProcessNameEnum processId, 
            int reasonId, string reasonContext, String updateTime)
        {
            Device device = new Device
            {
                Imei = imei,
                OrderId = orderId,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = (int)processId,
                UserId = loginInfo.userId,
                Passed = (int)PassJudge.Unqualified,
                ReasonId = reasonId,
                ReasonContext = reasonContext
            };
            if (updateTime != String.Empty)
            {
                device.EndTime = updateTime;
            }
            return PostProductDevice(loginInfo, device);
        }



        public JToken ProcessProdcueNum(LoginInfo loginInfo)
        {
            JObject jObject = DeviceBaoGongApi.ProcessProdcueNumApi(loginInfo);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
