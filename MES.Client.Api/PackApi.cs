using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ManufacturingExecutionSystem.MES.Client.Api
{
    internal static class PackApi
    {
        /// <summary>
        /// 获取箱单绑定设备
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="packId"></param>
        /// <returns></returns>
        public static JObject GetPackLinkDeviceApi(LoginInfo loginInfo, string packId)
        {
            return Common.BackgroundRequest("/prod-api/order/packDevice/" + packId, Method.GET, loginInfo?.Token);
        }


        /// <summary>
        /// 生成大箱单号
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="userId"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public static JObject GenerateBigPackApi(LoginInfo loginInfo, int saleOrderId)
        {
            GenerateBigPackObject generateBigPackObject = new GenerateBigPackObject
            {
                saleorderId = saleOrderId, userId = loginInfo.userId
            };

            return Common.BackgroundRequest("/prod-api/order/generatePackNo", Method.POST, loginInfo?.Token, generateBigPackObject, false);
        }



        public static JObject LinkDeviceToBigPackApi(LoginInfo loginInfo, String imei, String packId)
        {
            GenerateBigPackObject generateBigPackObject = new GenerateBigPackObject
            {
                packId = packId,
                imei = imei
            };

            return Common.BackgroundRequest("/prod-api/order/packDevice", Method.POST, loginInfo?.Token, generateBigPackObject, false);
        }


        [DataContract(Name = "GenerateBigPackObject")]
        class GenerateBigPackObject
        {
            [DataMember]
            [Description("操作人员")]
            public int userId { get; set; }

            [DataMember]
            [Description("销售单号")]
            public int saleorderId { get; set; }

            [DataMember]
            [Description("设备号")]
            public String imei { get; set; }

            [DataMember]
            [Description("箱号")]
            public String packId { get; set; }
        }

    }
}
