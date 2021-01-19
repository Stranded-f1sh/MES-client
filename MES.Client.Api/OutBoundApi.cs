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
    internal static class OutBoundApi
    {
        /// <summary>
        /// 设备出库
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="deviceObject"></param>
        /// <returns></returns>
        public static JObject PostOutBoundApi(LoginInfo loginInfo, Device deviceObject)
        {
            return Common.BackgroundRequest("/prod-api/order/outbound", Method.POST, loginInfo?.Token, deviceObject, true);
        }



        /// <summary>
        /// 获取设备报工记录接口(出库)
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="processId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public static JObject GetOutBoundProductDevicesApi(LoginInfo loginInfo, int saleOrderId, int processId, int pageSize, int pageNo)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices?processId=" + processId + "&pageNo=" + pageNo + "&pageSize=" + pageSize + "saleOrderId=" + saleOrderId, Method.GET, loginInfo?.Token);
        }


        /// <summary>
        /// 获取设备报工记录接口(出库)
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="processId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public static JObject GetOutBoundProductDevicesApi(LoginInfo loginInfo, int saleOrderId, int processId)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices?processId=" + processId + "&saleOrderId=" + saleOrderId, Method.GET, loginInfo?.Token);
        }
    }
}
