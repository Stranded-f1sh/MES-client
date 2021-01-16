using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    public class PackService
    {
        /// <summary>
        /// 获取箱单绑定设备
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="bigPack"></param>
        /// <returns></returns>
        public JToken GetPackLinkDevice(LoginInfo loginInfo, BigPack bigPack)
        {
            JObject jObject = PackApi.GetPackLinkDeviceApi(loginInfo, bigPack?.PackId);
            return MyJsonConverter.GetJToken(jObject);
        }


        /// <summary>
        /// 生成大箱单号
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public JToken GenerateBigPack(LoginInfo loginInfo, int saleOrderId)
        {
            JObject jObject = PackApi.GenerateBigPackApi(loginInfo, saleOrderId);
            return MyJsonConverter.GetJToken(jObject);
        }


        /// <summary>
        /// 箱单绑定
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <param name="imei"></param>
        /// <param name="packId"></param>
        /// <returns></returns>
        public JToken LinkDeviceToBigPack(LoginInfo loginInfo, String imei, String packId)
        {
            JObject jObject = PackApi.LinkDeviceToBigPackApi(loginInfo, imei, packId);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
