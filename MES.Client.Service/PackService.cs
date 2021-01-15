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
        public JToken GetPackLinkDevice(LoginInfo loginInfo, BigPack bigPack)
        {
            JObject jObject = PackApi.GetPackLinkDeviceApi(loginInfo, bigPack.PackId);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
