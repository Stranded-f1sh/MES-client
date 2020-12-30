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
    class QualifyService
    {
        public JToken GetUnQualifyReason(LoginInfo loginInfo, string processId)
        {
            JObject jObject = QualifyApi.GetUnQualifyReasonApi(loginInfo, processId);
            return JsonConverter.GetJToken(jObject);
        }
    }
}
