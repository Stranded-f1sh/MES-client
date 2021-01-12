using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "Device")]
    public class Device
    {
        [DataMember]
        [Description("设备号")]
        public String Imei { get; set; } // 设备号

        [DataMember]
        [Description("ICCID号")]
        public String Imsi { get; set; } // ICCID号

        [DataMember]
        [Description("生产订单号")]
        public int OrderId { get; set; } // 生产订单号

        [DataMember]
        [Description("工序号")]
        public int ProcessId { get; set; } // 工序号

        [DataMember]
        [Description("开始时间")]
        public String StartTime { get; set; } // 开始时间

        [DataMember]
        [Description("结束时间")]
        public String EndTime { get; set; } // 结束时间

        [DataMember]
        [Description("用户id")]
        public int UserId { get; set; } //用户id

        [DataMember]
        [Description("销售订单号")]
        public String SaleOrderId { get; set; } // 销售订单号

        [DataMember]
        [Description("箱单id")]
        public String PackId { get; set; } // 箱单id

        [DataMember]
        [Description("1为合格 0为不合格")]
        public int Passed { get; set; } // 1为合格 0为不合格

        [DataMember]
        [Description("原因分类")]
        public int ReasonId { get; set; } // 原因分类

        [DataMember]
        [Description("原因备注")]
        public String ReasonContext { get; set; } // 原因备注

        
        [DataMember]
        [Description("频点")]
        public String PinDian { get; set; } // 频点
        
        
        [DataMember]
        [Description("提交状态")]
        public SubmitStatus BaoGongStatus { get; set; } // 提交状态
    }
}
