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
    }
}
