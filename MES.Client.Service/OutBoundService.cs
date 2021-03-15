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
    class OutBoundService
    {
        LogInfoHelper _logger = new LogInfoHelper();

        public JToken PostOutBound(LoginInfo loginInfo, Device deviceObject)
        {
            JObject jObject = OutBoundApi.PostOutBoundApi(loginInfo, deviceObject);
            _logger.printLog("出库：" + jObject + "\r\n" + deviceObject?.Imei + "\r\n 销售单id：" + deviceObject.SaleOrderId + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);
            return MyJsonConverter.GetJToken(jObject);
        }


        public JToken GetOutBoundProductDevices(LoginInfo loginInfo, int saleOrderId, int processId)
        {
            JObject jObject = OutBoundApi.GetOutBoundProductDevicesApi(loginInfo, saleOrderId, processId);
            return MyJsonConverter.GetJTokenList(jObject);
        }


        public JToken GetIpAddressByUserName(LoginInfo loginInfo, SaleOrder SaleOrderInfo)
        {
            JObject jObject = OutBoundApi.GetIpAddressByUserNameApi(loginInfo, SaleOrderInfo.CompanyFullName, SaleOrderInfo.PlatFormType);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
