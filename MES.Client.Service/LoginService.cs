using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Mapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class LoginService
    {
        public LoginInfo GetToken(String userName, String passWord)
        {
            LoginInfo loginInfo = new LoginInfo { username = userName, password = passWord};
            JObject jToken = LoginApi.GetTokenApi(loginInfo);
            if (jToken?.Property("code") == null || jToken["code"]?.ToString() != "0") return null;
            loginInfo.Token = jToken["data"]?["token"]?.ToString();
            loginInfo.userId = int.Parse(jToken["data"]?["id"]?.ToString()?? String.Empty);
            return loginInfo;
        }


        public JToken GetUserList(LoginInfo loginInfo)
        {
            JObject userList = LoginApi.GetUserListApi(loginInfo);
            return MyJsonConverter.GetJTokenList(userList);
        }



        public int SetUserPassWd(LoginInfo loginInfo)
        {
            LoginMapper loginMapper = new LoginMapper();
            loginMapper.CreateTableIfNotExist();

            return loginMapper.InsertIntoLoginInfo(loginInfo);
        }


        public int UpDateUserPassWd(LoginInfo loginInfo)
        {
            LoginMapper loginMapper = new LoginMapper();
            loginMapper.CreateTableIfNotExist();

            return loginMapper.UpdateLoginInfoById(loginInfo);
        }


        public DataSet GetUserPassWdCache()
        {
            LoginMapper loginMapper = new LoginMapper();
            loginMapper.CreateTableIfNotExist();
            DataSet selectLoginInfo = loginMapper.SelectLoginInfo();
            return selectLoginInfo;
        }
    }
}
