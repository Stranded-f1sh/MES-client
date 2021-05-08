
using System;
using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class ProductOrderApi
    {
        /// <summary>
        /// 获取所有工单信息接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public static JObject GetProductOrderApi(LoginInfo loginInfo)
        {
            return Common.BackgroundRequest("/prod-api/order/productOrders", Method.GET, loginInfo?.Token);
        }


        public static JObject GetProductOrderInfoApi(LoginInfo loginInfo, int orderId)
        {
            return Common.BackgroundRequest("/prod-api/order/productOrders?id=" + orderId, Method.GET, loginInfo?.Token);
        }

        /// <summary>
        /// 根据IMEI号获取工单号
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="imei"></param>
        /// <returns></returns>
        public static JObject FindProductOrderIdByImeiApi(LoginInfo loginInfo, String imei)
        {
            return Common.BackgroundRequest("/prod-api/order/deviceOrder?imei=" + imei, Method.GET, loginInfo?.Token);
        }
    }
}
