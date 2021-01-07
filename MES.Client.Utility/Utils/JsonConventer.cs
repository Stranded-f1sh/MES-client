using System;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    internal static class MyJsonConverter
    {
        public static JToken GetJTokenList(JObject jObject)
        {
            if (jObject?.Property("code") != null && jObject["code"]?.ToString() == "0")
            {
                return jObject["data"]?["list"];
            }
            return null;
        }



        // public void JObjectTo

        public static JToken GetJToken(JObject jObject)
        {
            if (jObject?.Property("code") != null && jObject["code"]?.ToString() == "0")
            {
                return jObject["data"];
            }
            return jObject?["msg"];
        }


        /// <summary>
        /// 判断请求后JToken返回的字段是否存在
        /// </summary>
        /// <param name="jToken"> i["example"] </param>
        /// <returns></returns>
        public static String JTokenTransformer(JToken jToken)
        {
            if (jToken != null)
            {
                return jToken.ToString();
            }
            return " ";
        }
    }
}
