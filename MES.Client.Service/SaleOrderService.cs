using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = ManufacturingExecutionSystem.MES.Client.Utility.Utils.JsonConverter;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class SaleOrderService
    {
        public JToken GetSaleOrderInfo(LoginInfo loginInfo, string saleOrderId)
        {
            JObject jObject = SaleOrderApi.GetSaleOrderInfoApi(loginInfo, saleOrderId);

            return JsonConverter.GetJTokenList(jObject);
        }


        public SaleOrder SetSaleOrderInfo(JToken jtoken)
        {
            SaleOrder saleOrder = null;
            foreach (JToken jToken in jtoken)
            {
                saleOrder = new SaleOrder
                {
                    orderNo = JsonConverter.JTokenTransformer(jToken?["orderNo"]),
                    customerDeviceName = JsonConverter.JTokenTransformer(jToken?["customerDeviceName"]),
                    customerDeviceModel = JsonConverter.JTokenTransformer(jToken?["customerDeviceModel"]),
                    companyFullName = JsonConverter.JTokenTransformer(jToken?["companyFullName"]),
                    buyNumber = int.Parse(JsonConverter.JTokenTransformer(jToken?["buyNumber"]) ?? string.Empty),
                    buyDate = JsonConverter.JTokenTransformer(jToken?["buyDate"])
                };

                string value = JsonConverter.JTokenTransformer(jToken?["orderDetail"]);
                JObject orderDetail = (JObject)JsonConvert.DeserializeObject(value ?? string.Empty);

                if (orderDetail?["range"] == null) return null;

                foreach (var m in orderDetail["range"])
                {
                    saleOrder.defaultConfig = m.First.ToString();
                    var h = m.Next?.First?.ToString();
                    if (h != "")
                    {
                        saleOrder.defaultConfig = h;
                    }
                    break;
                }
            }
            return saleOrder;
        }



    }
}
