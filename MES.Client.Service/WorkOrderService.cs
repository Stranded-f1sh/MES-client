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
    class WorkOrderService
    {
        public JToken GetProductOrders(LoginInfo loginInfo)
        {
            JObject jToken = Common.BackgroundRequest("/prod-api/order/productOrders", Method.GET, loginInfo?.Token);

            return JsonConverter.GetJTokenList(jToken);
        }
    }
}
