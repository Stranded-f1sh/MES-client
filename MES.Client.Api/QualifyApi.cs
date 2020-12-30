using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class QualifyApi
    {
        /// <summary>
        /// 获取不合格报工原因接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="processId"></param>
        /// <returns></returns>
        public static JObject GetUnQualifyReasonApi(LoginInfo loginInfo, string processId)
        {
            return Common.BackgroundRequest("/prod-api/process/processReason/" + processId, Method.GET, loginInfo?.Token);
        }
    }
}
