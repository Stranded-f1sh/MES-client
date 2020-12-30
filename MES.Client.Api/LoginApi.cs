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
    internal static class LoginApi
    {
        /// <summary>
        /// 获取TOKEN接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public static JObject GetTokenApi(LoginInfo loginInfo)
        {
            return Common.BackgroundRequest("/prod-api/auth/login", Method.POST, loginInfo);
        }


        /// <summary>
        /// 获取用户及其拥有权限的工序列表接口
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        public static JObject GetUserListApi(LoginInfo loginInfo)
        {
            return Common.BackgroundRequest("/prod-api/user/list", Method.GET, loginInfo?.Token);
        }
    }
}
