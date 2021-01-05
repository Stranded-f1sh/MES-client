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
            return JsonConverter.GetJToken(jObject);
        }


        public JToken DeviceBaoGong(LoginInfo loginInfo, String imei, String orderId, String processId
            , String userId, PassJudge passJudge, int reasonId, string reasonContext)
        {
            Device device = new Device
            {
                imei = imei,
                orderId = orderId,
                endTime = DateTime.Now.AddHours(-8).ToString(@"yyyy-MM-dd'T'HH:mm:ss.sssZ"),
                processId = processId,
                userId = userId
            };
            switch (passJudge)
            {
                case PassJudge.Qualified:
                    device.passed = (int)PassJudge.Qualified;

                    break;
                case PassJudge.Unqualified:
                    device.passed = (int)PassJudge.Unqualified;
                    device.reasonId = reasonId;
                    device.reasonContext = reasonContext;
                    break;
            }

            return PostProductDevice(loginInfo, device);
        }
    }
}
