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
    internal static class PackApi
    {

        public static JObject GetPackLinkDeviceApi(LoginInfo loginInfo, string packId)
        {
            return Common.BackgroundRequest("/prod-api/order/packDevice/" + packId, Method.GET, loginInfo?.Token);
        }
    }
}
