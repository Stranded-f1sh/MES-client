using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Diagnostics;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class Common
    {
        /// <summary>
        /// 添加Headers
        /// </summary>
        /// <returns> ICollection&lt;KeyValuePair&lt;string, string&gt;&gt; </returns>
        private static ICollection<KeyValuePair<string, string>> AddHeaders(string token)
        {
            ICollection<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> avpAccept = new KeyValuePair<string, string>("Accept", "application/json, text/plain, */*");
            KeyValuePair<string, string> acceptEncoding = new KeyValuePair<string, string>("Accept-Encoding", "gzip, deflate");
            KeyValuePair<string, string> acceptLanguage = new KeyValuePair<string, string>("Accept-Language", "en,zh-CN;q=0.9,zh;q=0.8,jv;q=0.7");
            KeyValuePair<string, string> connection = new KeyValuePair<string, string>("Connection", "keep-alive");
            KeyValuePair<string, string> host = new KeyValuePair<string, string>("Host", "47.97.117.253:8092");
            KeyValuePair<string, string> referer = new KeyValuePair<string, string>("Referer", "http://47.97.117.253:8092/");
            KeyValuePair<string, string> userAgent = new KeyValuePair<string, string>("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");
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
            KeyValuePair<string, string> avpAccept = new KeyValuePair<string, string>("Accept", "application/json, text/plain, */*");
            KeyValuePair<string, string> acceptEncoding = new KeyValuePair<string, string>("Accept-Encoding", "gzip, deflate");
            KeyValuePair<string, string> acceptLanguage = new KeyValuePair<string, string>("Accept-Language", "en,zh-CN;q=0.9,zh;q=0.8,jv;q=0.7");
            KeyValuePair<string, string> connection = new KeyValuePair<string, string>("Connection", "keep-alive");
            KeyValuePair<string, string> host = new KeyValuePair<string, string>("Host", "47.97.117.253:8092");
            KeyValuePair<string, string> referer = new KeyValuePair<string, string>("Referer", "http://47.97.117.253:8092/");
            KeyValuePair<string, string> userAgent = new KeyValuePair<string, string>("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");

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
            var client = new RestClient("http://47.97.117.253:8092");
            var request = new RestRequest(url, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders(token);
            request.AddHeaders(headers);
            var json = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            JObject jObject = (JObject)JsonConvert.DeserializeObject(content);
            return jObject;
        }


        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <param name="token"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject BackgroundRequest(string url, Method method, object obj)
        {
            var client = new RestClient("http://47.97.117.253:8092");
            var request = new RestRequest(url, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders();
            request.AddHeaders(headers);
            var json = JsonConvert.SerializeObject(obj);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
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
            var client = new RestClient("http://47.97.117.253:8092");
            var request = new RestRequest(url ?? string.Empty, method);
            ICollection<KeyValuePair<string, string>> headers = AddHeaders(token);
            request.AddHeaders(headers ?? throw new InvalidOperationException());
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            JObject jObject = (JObject)JsonConvert.DeserializeObject(content);
            return jObject;
        }
    }
}
