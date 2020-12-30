using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class RegistrationService
    {
        public JToken PostRegisterDevice(LoginInfo loginInfo, String saleOrderId, Device deviceObject)
        {
            JObject jObject = DeviceRegistrationApi.PostRegisterDeviceApi(loginInfo, saleOrderId, deviceObject?.imei, deviceObject?.imsi);
            return JsonConverter.PostJToken(jObject);
        }

    }
}
