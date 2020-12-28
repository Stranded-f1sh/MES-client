using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    internal static class JsonConverter
    {
        // public void JObjectTo

        public static JToken GetJTokenList(JObject jObject)
        {
            if (jObject?.Property("code") != null && jObject["code"]?.ToString() == "0")
            {
                if (jObject["data"]?["list"] != null && jObject["data"]["list"].HasValues)
                {
                    return jObject["data"]?["list"];
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// 判断请求后JToken返回的字段是否存在
        /// </summary>
        /// <param name="jtoken"> i["example"] </param>
        /// <returns></returns>
        public static String JTokenTransformer(JToken jtoken)
        {
            if (jtoken != null)
            {
                return jtoken.ToString();
            }
            return " ";
        }
    }
}
