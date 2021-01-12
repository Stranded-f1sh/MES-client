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
        /*
         * 所有工单列表获取
         */
        public JToken GetProductOrders(LoginInfo loginInfo)
        {
            JObject jObject = ProductOrderApi.GetProductOrderApi(loginInfo);

            return MyJsonConverter.GetJTokenList(jObject);
        }


        /*
         * 分页查询
         */
        public JToken GetProductDeviceRecord(LoginInfo loginInfo, string orderId, string processId, int pageSize, int pageNo)
        {
            JObject jObject = DeviceBaoGongApi.GetProductDevicesApi(loginInfo, orderId, processId, pageSize, pageNo);

            return MyJsonConverter.GetJToken(jObject);
        }


        /*
         * 查询全部
         */
        public JToken GetProductDeviceRecord(LoginInfo loginInfo, string orderId, string processId)
        {
            JObject jObject = DeviceBaoGongApi.GetProductDevicesApi(loginInfo, orderId, processId);

            return MyJsonConverter.GetJToken(jObject);
        }


        /*
         * 根据imei号查询工单id
         */
        public JToken FindProductOrderIdByImei(LoginInfo loginInfo, String imei)
        {
            JObject jObject = ProductOrderApi.FindProductOrderIdByImeiApi(loginInfo, imei);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
