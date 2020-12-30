using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class SaleOrderApi
    {
        /// <summary>
        /// 获取销售订单信息接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public static JObject GetSaleOrderInfoApi(LoginInfo loginInfo, string saleOrderId)
        {
            return Common.BackgroundRequest("/prod-api/order/saleOrders?id=" + saleOrderId, Method.GET, loginInfo?.Token);
        }
    }
}
