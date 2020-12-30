using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "SaleOrder")]
    class SaleOrder
    {
        [DataMember]
        [Description("订单编号")]
        public String orderNo { get; set; } // 订单编号

        [DataMember]
        [Description("客户名称")]
        public String companyFullName { get; set; } // 客户名称

        [DataMember]
        [Description("客户产品名称")]
        public String customerDeviceName { get; set; } // 客户产品名称

        [DataMember]
        [Description("客户产品型号")]
        public String customerDeviceModel { get; set; } // 客户产品型号

        [DataMember]
        [Description("订单数量")]
        public int buyNumber { get; set; } // 订单数量

        [DataMember]
        [Description("订单日期")]
        public String buyDate { get; set; } // 订单日期

        [DataMember]
        [Description("量程")]
        public String defaultConfig { get; set; } // 量程
    }
}
