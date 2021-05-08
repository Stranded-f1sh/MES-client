using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class WareHouseInspactApi
    {
        /// <summary>
        /// 检验数据上报
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="inspactResult"></param>
        /// <returns></returns>
        public static JObject InspactResultUponApi(LoginInfo loginInfo, InspactResult inspactResult)
        {
            return Common.BackgroundRequest("/prod-api/process/deviceTest", Method.POST, loginInfo.Token, inspactResult, false);
        }

        /// <summary>
        /// 根据imei号查找检验结果
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="imei"></param>
        /// <returns></returns>
        public static JObject FindValueByImeiApi(LoginInfo loginInfo, String imei)
        {
            return Common.BackgroundRequest("/prod-api/process/deviceTest?imei=" + imei, Method.GET, loginInfo.Token);
        }

        /// <summary>
        /// 根据订单查找报工设备检验结果
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static JObject FindValueByOrderIdApi(LoginInfo loginInfo, int orderId)
        {
            return Common.BackgroundRequest("/prod-api/process/deviceTest?orderId=" + orderId, Method.GET, loginInfo.Token);
        }
    }
}
