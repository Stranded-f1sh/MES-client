using System;
using ManufacturingExecutionSystem.MES.Client.Api;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;
using Newtonsoft.Json.Linq;

namespace ManufacturingExecutionSystem.MES.Client.Service
{
    class RegistrationService
    {
        LogInfoHelper _logger = new LogInfoHelper();
        public JToken PostRegisterDevice(LoginInfo loginInfo, String saleOrderId, Device deviceObject)
        {
            JObject jObject = DeviceRegistrationApi.PostRegisterDeviceApi(loginInfo, saleOrderId, deviceObject?.Imei, deviceObject?.Imsi);
            _logger.printLog("注册接口调用：" + jObject + "\r\n"+ deviceObject?.Imei + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);
            return MyJsonConverter.GetJToken(jObject);
        }



        public JToken DelDevice(LoginInfo loginInfo, Device deviceObject, SaleOrder saleOrder)
        {
            JObject jObject = DeviceRegistrationApi.delDeviceApi(loginInfo, deviceObject?.Imei, saleOrder?.PlatFormType);
            _logger.printLog("删除接口调用：" + jObject + "\r\n" + deviceObject?.Imei + "\r\n", LogInfoHelper.LOG_TYPE.LOG_INFO);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
