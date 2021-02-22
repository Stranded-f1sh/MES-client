using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "SaleOrder")]
    public class SaleOrder
    {
        [DataMember]
        [Description("订单id")]
        public int Id { get; set; } // 订单id

        [DataMember]
        [Description("订单编号")]
        public String OrderNo { get; set; } // 订单编号

        [DataMember]
        [Description("订单日期")]
        public String BuyDate { get; set; } // 订单日期

        [DataMember]
        [Description("客户地址")]
        public String Address { get; set; } // 客户地址

        [DataMember]
        [Description("客户名称")]
        public String CompanyFullName { get; set; } // 客户名称

        [DataMember]
        [Description("客户产品名称")]
        public String CustomerDeviceName { get; set; } // 客户产品名称

        [DataMember]
        [Description("客户产品型号")]
        public String CustomerDeviceModel { get; set; } // 客户产品型号

        [DataMember]
        [Description("订单数量")]
        public int BuyNumber { get; set; } // 订单数量

        [DataMember]
        [Description("量程")]
        public String DefaultConfig { get; set; } // 量程

        [DataMember]
        [Description("平台类型")]
        public String PlatFormType { get; set; } // 平台类型

        [DataMember]
        [Description("ip地址")]
        public String IpAddress { get; set; } // ip地址
    }
}
