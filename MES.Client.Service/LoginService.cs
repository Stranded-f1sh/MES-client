using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    internal class LoginService
    { 
        public LoginInfo GetToken(String userName, String passWord)
        {
            LoginInfo loginInfo = new LoginInfo { username = userName, password = passWord};
            JObject jToken = Common.BackgroundRequest("/prod-api/auth/login", Method.POST, loginInfo);
            if (jToken?.Property("code") != null && jToken["code"]?.ToString() == "0")
            {
                loginInfo.Token = jToken["data"]?["token"]?.ToString();
                loginInfo.userId = jToken["data"]?["id"]?.ToString();
                return loginInfo;
            }
            return null;
        }


        public JToken GetUserList(LoginInfo loginInfo)
        {
            JObject userList = Common.BackgroundRequest("/prod-api/user/list", Method.GET, loginInfo?.Token);
            return JsonConverter.GetJTokenList(userList);
        }
    }
}
