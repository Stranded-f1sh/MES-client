using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "LoginInfo")]
    public class LoginInfo
    {
        [DataMember]
        public String userId { get; set; }
        [DataMember]
        public String User { get; set; }
        [DataMember]
        public String username { get; set; }
        [DataMember]
        public String password { get; set; }
        [DataMember]
        public String UserProcessPrivilege { get; set; }
        [DataMember]
        public String Token { get; set; }
    }
}
