using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("操作员工id")]
        public int userId { get; set; }

        [DataMember]
        [Description("操作员工名")]
        public String User { get; set; }

        [DataMember]
        [Description("登录账户")]
        public String username { get; set; }

        [DataMember]
        [Description("登录密码")]
        public String password { get; set; }

        [DataMember]
        [Description("拥有的工序权限")]
        public String UserProcessPrivilege { get; set; }

        [DataMember]
        [Description("接口调用权限")]
        public String Token { get; set; }
    }
}
