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
        public static JObject GetSaleOrderInfoApi(LoginInfo loginInfo, String saleOrderId)
        {
            return Common.BackgroundRequest("/prod-api/order/saleOrders?id=" + saleOrderId, Method.GET, loginInfo?.Token);
        }


        /// <summary>
        /// 获取销售订单接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="selectedYear"></param>
        /// <returns></returns>
        public static JObject GetSaleOrdersApi(LoginInfo loginInfo, int selectedYear)
        {
            return Common.BackgroundRequest("/prod-api/order/monthsaleorders?year=" + selectedYear + "&month=-1", Method.GET, loginInfo?.Token);
            
        }



        /// <summary>
        /// 转正式客户
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="imei"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public static JObject PublishDeviceApi(LoginInfo loginInfo, String imei, int saleOrderId)
        {
            return Common.BackgroundRequest("/prod-api/order/publishDevice?imei=" + imei + "&orderId=" + saleOrderId, Method.GET, loginInfo?.Token);
        }



        /// <summary>
        /// 根据销售单id获取大箱单
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public static JObject GetBigPackApi(LoginInfo loginInfo, int saleOrderId)
        {
            return Common.BackgroundRequest("/prod-api/order/orderPack/" + saleOrderId, Method.GET, loginInfo?.Token);
        }
    }
}
