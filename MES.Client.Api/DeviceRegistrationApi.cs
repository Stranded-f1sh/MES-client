using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class DeviceRegistrationApi
    {

        /// <summary>
        /// 设备注册接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="orderId"></param>
        /// <param name="imei"></param>
        /// <param name="imsi"></param>
        /// <returns></returns>
        public static JObject PostRegisterDeviceApi(LoginInfo loginInfo, string orderId, string imei, string imsi)
        {
            return Common.BackgroundRequest("/prod-api/order/registerDevice?orderId=" + orderId + "&imei=" + imei + "&imsi=" + imsi, Method.GET, loginInfo?.Token);
        }
    }
}
