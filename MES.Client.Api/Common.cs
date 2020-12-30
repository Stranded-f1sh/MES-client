using System;
using System.Collections.Generic;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class Common
    {
        private static readonly AppSettingsSection AppSettingsSection;
        static Common()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection = config.AppSettings;
        }

        /// <summary>
        /// 添加Headers
        /// </summary>
        /// <returns> ICollection&lt;KeyValuePair&lt;string, string&gt;&gt; </returns>
        private static ICollection<KeyValuePair<string, string>> AddHeaders(string token)
        {
            ICollection<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> avpAccept = new KeyValuePair<string, string>("Accept", AppSettingsSection?.Settings?["Accept"]?.Value);
            KeyValuePair<string, string> acceptEncoding = new KeyValuePair<string, string>("Accept-Encoding", AppSettingsSection?.Settings?["Accept-Encoding"]?.Value);
            KeyValuePair<string, string> acceptLanguage = new KeyValuePair<string, string>("Accept-Language", AppSettingsSection?.Settings?["Accept-Language"]?.Value);
            KeyValuePair<string, string> connection = new KeyValuePair<string, string>("Connection", AppSettingsSection?.Settings?["Connection"]?.Value);
            KeyValuePair<string, string> host = new KeyValuePair<string, string>("Host", AppSettingsSection?.Settings?["Host"]?.Value);
            KeyValuePair<string, string> referer = new KeyValuePair<string, string>("Referer", AppSettingsSection?.Settings?["Referer"]?.Value);
            KeyValuePair<string, string> userAgent = new KeyValuePair<string, string>("User-Agent", AppSettingsSection?.Settings?["User-Agent"]?.Value);
            KeyValuePair<string, string> authorization = new KeyValuePair<string, string>("Authorization", token);

            headers.Add(avpAccept);
            headers.Add(acceptEncoding);
            headers.Add(acceptLanguage);
            headers.Add(connection);
            headers.Add(host);
            headers.Add(referer);
            headers.Add(userAgent);
            headers.Add(authorization);
            return headers;
        }


        /// <summary>
        /// 添加Headers
        /// </summary>
        /// <returns> ICollection&lt;KeyValuePair&lt;string, string&gt;&gt; </returns>
        private static ICollection<KeyValuePair<string, string>> AddHeaders()
        {
            ICollection<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> avpAccept = new KeyValuePair<string, string>("Accept", AppSettingsSection?.Settings?["Accept"]?.Value);
            KeyValuePair<string, string> acceptEncoding = new KeyValuePair<string, string>("Accept-Encoding", AppSettingsSection?.Settings?["Accept-Encoding"]?.Value);
            KeyValuePair<string, string> acceptLanguage = new KeyValuePair<string, string>("Accept-Language", AppSettingsSection?.Settings?["Accept-Language"]?.Value);
            KeyValuePair<string, string> connection = new KeyValuePair<string, string>("Connection", AppSettingsSection?.Settings?["Connection"]?.Value);
            KeyValuePair<string, string> host = new KeyValuePair<string, string>("Host", AppSettingsSection?.Settings?["Host"]?.Value);
            KeyValuePair<string, string> referer = new KeyValuePair<string, string>("Referer", AppSettingsSection?.Settings?["Referer"]?.Value);
            KeyValuePair<string, string> userAgent = new KeyValuePair<string, string>("User-Agent", AppSettingsSection?.Settings?["User-Agent"]?.Value);

            headers.Add(avpAccept);
            headers.Add(acceptEncoding);
            headers.Add(acceptLanguage);
            headers.Add(connection);
            headers.Add(host);
            headers.Add(referer);
            headers.Add(userAgent);
            return headers;
        }


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="token"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject BackgroundRequest(string url, Method method, string token, object obj)
        {
            var client = new RestClient(AppSettingsSection?.Settings?["MesBackEndIpAddress"]?.Value ?? string.Empty);
            var request = new RestRequest(url ?? string.Empty, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders(token);
            request.AddHeaders(headers ?? throw new InvalidOperationException());
            var json = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            request.Timeout = 5000;
            int retryTimes = 0;
            IRestResponse response;

            do
            {
                response = client.Execute(request);
                retryTimes++;
            } while ((response.ResponseStatus != ResponseStatus.Completed) && retryTimes < 3);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }
            string content = response.Content;
            JObject jObject = (JObject)JsonConvert.DeserializeObject(content);
            return jObject;
        }


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject BackgroundRequest(string url, Method method, object obj)
        {
            var client = new RestClient(AppSettingsSection?.Settings?["MesBackEndIpAddress"]?.Value ?? string.Empty);
            var request = new RestRequest(url ?? string.Empty, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders();
            request.AddHeaders(headers ?? throw new InvalidOperationException());
            var json = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.Timeout = 5000;
            int retryTimes = 0;
            IRestResponse response;
            do
            {
                response = client.Execute(request);
                retryTimes++;
            } while ((response.ResponseStatus != ResponseStatus.Completed) && retryTimes < 3);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }
            string content = response.Content;
            JObject jObject = (JObject)JsonConvert.DeserializeObject(content);
            return jObject;
        }



        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JObject BackgroundRequest(string url, Method method, string token)
        {
            var client = new RestClient(AppSettingsSection?.Settings?["MesBackEndIpAddress"]?.Value ?? string.Empty);
            var request = new RestRequest(url ?? string.Empty, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders(token);
            request.AddHeaders(headers ?? throw new InvalidOperationException());
            request.Timeout = 5000;
            int retryTimes = 0;
            IRestResponse response;
            do
            {
                response = client.Execute(request);
                retryTimes ++;
            } while ((response.ResponseStatus != ResponseStatus.Completed) && retryTimes < 3);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }
            string content = response.Content;
            JObject jObject = (JObject)JsonConvert.DeserializeObject(content);
            return jObject;
        }
    }
}
