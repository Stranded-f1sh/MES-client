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


        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, String orderId, String processId
            , String userId, PassJudge passJudge, int reasonId, string reasonContext)
        {
            Device device = new Device
            {
                Imei = imei,
                OrderId = orderId,
                EndTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                ProcessId = processId,
                UserId = userId
            };
            switch (passJudge)
            {
                case PassJudge.Qualified:
                    device.Passed = (int)PassJudge.Qualified;

                    break;
                case PassJudge.Unqualified:
                    device.Passed = (int)PassJudge.Unqualified;
                    device.ReasonId = reasonId;
                    device.ReasonContext = reasonContext;
                    break;
            }

            return PostProductDevice(loginInfo, device);
        }
    }
}
