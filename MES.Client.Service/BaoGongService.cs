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
        /// <param name="userId"></param>
        /// <returns></returns>
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, ProcessNameEnum processId)
        {
            Device device = new Device
            {
                Imei = imei,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = (int)processId,
                UserId = loginInfo.userId,
                Passed = (int)PassJudge.Qualified
            };
            return PostProductDevice(loginInfo, device);
        }
        
        
        /**
         * 需要传不合格原因
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, ProcessNameEnum processId, 
            int reasonId, string reasonContext)
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
            return PostProductDevice(loginInfo, device);
        }
        
        
        /**
         * 需要传工单号
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, int orderId, ProcessNameEnum processId)
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
            
            return PostProductDevice(loginInfo, device);
        }

        
        /**
         * 需要传工单号 和 不合格原因
         */
        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, int orderId, ProcessNameEnum processId, 
            int reasonId, string reasonContext)
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
            
            return PostProductDevice(loginInfo, device);
        }
    }
}
