using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "BigPack")]
    public class BigPack
    {
        [DataMember]
        [Description("客户名称")]
        public String CompanyFullName { get; set; } // 客户名称


        [DataMember]
        [Description("设备名称")]
        public String CustomerDeviceName { get; set; } // 设备名称


        [DataMember]
        [Description("设备型号")]
        public String CustomerDeviceModel { get; set; } // 设备型号


        [DataMember]
        [Description("箱号")]
        public String PackId { get; set; } // 设备型号


        [DataMember]
        [Description("设备数量")]
        public String DeviceCount { get; set; } // 设备型号


        [DataMember]
        [Description("订单号")]
        public String OrderNo { get; set; } // 设备型号


        [DataMember]
        [Description("编码号")]
        public String PackNo { get; set; } // 设备型号


        [DataMember]
        [Description("FRX文件")]
        public String FrxFileModel { get; set; } // FRX文件
    }
}
