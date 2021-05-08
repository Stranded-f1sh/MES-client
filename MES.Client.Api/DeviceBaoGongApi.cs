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
            return Common.BackgroundRequest("/prod-api/order/productDevices", Method.POST, loginInfo?.Token, deviceObject, true);
        }


        /// <summary>
        /// 获取所有设备报工记录接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="orderId"></param>
        /// <param name="processId"></param>
        /// <returns></returns>
        public static JObject GetProductDevicesApi(LoginInfo loginInfo, string orderId, string processId)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices?orderId=" + orderId + "&processId=" + processId, Method.GET, loginInfo?.Token);
        }


        /// <summary>
        /// 获取设备报工记录接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="orderId"></param>
        /// <param name="processId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public static JObject GetProductDevicesApi(LoginInfo loginInfo, string orderId, string processId, int pageSize, int pageNo)
        {
            return Common.BackgroundRequest("/prod-api/order/productDevices?orderId=" + orderId + "&processId=" + processId + "&pageNo="+ pageNo + "&pageSize="+ pageSize, Method.GET, loginInfo?.Token);
        }



        /// <summary>
        /// 工序日产量
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public static JObject ProcessProdcueNumApi(LoginInfo loginInfo)
        {
            return Common.BackgroundRequest("/prod-api/order/querytable?table=process_day_count", Method.GET, loginInfo?.Token);
        }
    }
}
