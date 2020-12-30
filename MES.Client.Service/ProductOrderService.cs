using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class ProductOrderService
    {
        public JToken GetProductOrders(LoginInfo loginInfo)
        {
            JObject jObject = ProductOrderApi.GetProductOrderApi(loginInfo);

            return JsonConverter.GetJTokenList(jObject);
        }


        public JToken GetRegistrationDeviceRecord(LoginInfo loginInfo, string orderId, string processId)
        {
            JObject jObject = DeviceBaoGongApi.GetProductDevicesApi(loginInfo, orderId, processId);

            return JsonConverter.GetJTokenList(jObject);
        }
    }
}
