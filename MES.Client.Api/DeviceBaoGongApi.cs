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
    internal static class DeviceBaoGongApi
    {
        /// <summary>
        /// 设备报工接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="deviceObject"></param>
        /// <returns></returns>
        public static JObject PostProductDevicesApi(LoginInfo loginInfo, Device deviceObject)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices", Method.POST, loginInfo?.Token, deviceObject);
        }



        /// <summary>
        /// 获取设备报工记录接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="orderId"></param>
        /// <param name="processId"></param>
        /// <returns></returns>
        public static JObject GetProductDevicesApi(LoginInfo loginInfo, string orderId, string processId)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices?orderId=" + orderId + "&processId=" + processId, Method.GET, loginInfo?.Token);
        }
    }
}
