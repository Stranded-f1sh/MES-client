using System;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = ManufacturingExecutionSystem.MES.Client.Utility.Utils.MyJsonConverter;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class SaleOrderService
    {
        LogInfoHelper _logger = new LogInfoHelper();

        public JToken GetSaleOrderInfo(LoginInfo loginInfo, string saleOrderId)
        {
            JObject jObject = SaleOrderApi.GetSaleOrderInfoApi(loginInfo, saleOrderId);

            return JsonConverter.GetJTokenList(jObject);
        }


        public JToken GetSaleOrders(LoginInfo loginInfo, int selectedYear)
        {
            JObject jObject = SaleOrderApi.GetSaleOrdersApi(loginInfo, selectedYear);

            return JsonConverter.GetJToken(jObject);
        }


        public SaleOrder SetSaleOrderInfo(JToken jToken)
        {
            SaleOrder saleOrder = null;
            if (jToken == null) return null;
            foreach (JToken itemToken in jToken)
            {
                saleOrder = new SaleOrder
                {
                    Id = int.Parse(JsonConverter.JTokenTransformer(itemToken?["id"]) ?? String.Empty),
                    OrderNo = JsonConverter.JTokenTransformer(itemToken?["orderNo"]),
                    CustomerDeviceName = JsonConverter.JTokenTransformer(itemToken?["customerDeviceName"]),
                    CustomerDeviceModel = JsonConverter.JTokenTransformer(itemToken?["customerDeviceModel"]),
                    CompanyFullName = JsonConverter.JTokenTransformer(itemToken?["companyFullName"]),
                    BuyNumber = int.Parse(JsonConverter.JTokenTransformer(itemToken?["buyNumber"]) ?? String.Empty),
                    BuyDate = JsonConverter.JTokenTransformer(itemToken?["buyDate"]),
                    PlatFormType = JsonConverter.JTokenTransformer(itemToken?["platformType"])
                };

                string value = JsonConverter.JTokenTransformer(itemToken?["orderDetail"]);
                JObject orderDetail = (JObject)JsonConvert.DeserializeObject(value ?? String.Empty);

                if (orderDetail?["range"] == null) return null;

                foreach (var m in orderDetail["range"])
                {
                    saleOrder.DefaultConfig = m?.First?.ToString();
                    var h = m?.Next?.First?.ToString();
                    if (h != "")
                    {
                        saleOrder.DefaultConfig = h;
                    }
                    break;
                }
            }
            return saleOrder;
        }



        /// <summary>
        /// 转正式客户
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="deviceObject"></param>
        /// <returns></returns>
        public JToken PublishDevice(LoginInfo loginInfo, Device deviceObject)
        {
            if (deviceObject == null) return null;

            JObject jObject = SaleOrderApi.PublishDeviceApi(loginInfo, deviceObject.Imei, deviceObject.SaleOrderId);
            _logger.printLog("转正式客户：" + jObject + "\r\n" + deviceObject?.Imei + "\r\n 销售单id："+ deviceObject.SaleOrderId + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);
            return JsonConverter.GetJToken(jObject);
        }



        /// <summary>
        /// 根据销售单id获取大箱单
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public JToken GetBigPack(LoginInfo loginInfo, int saleOrderId)
        {
            JObject jObject = SaleOrderApi.GetBigPackApi(loginInfo, saleOrderId);
            return JsonConverter.GetJToken(jObject);
        }
    }
}
