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
        public JToken PostOutBound(LoginInfo loginInfo, Device deviceObject)
        {
            JObject jObject = OutBoundApi.PostOutBoundApi(loginInfo, deviceObject);
            return MyJsonConverter.GetJToken(jObject);
        }
    }
}
