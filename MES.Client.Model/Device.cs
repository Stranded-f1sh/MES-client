using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "Device")]
    class Device
    {
        [DataMember]
        [Description("设备号")]
        public String imei { get; set; } // 设备号

        [DataMember]
        [Description("ICCID号")]
        public String imsi { get; set; } // ICCID号

        [DataMember]
        [Description("生产订单号")]
        public String orderId { get; set; } // 生产订单号

        [DataMember]
        [Description("工序号")]
        public String processId { get; set; } // 工序号

        [DataMember]
        [Description("开始时间")]
        public String startTime { get; set; } // 开始时间

        [DataMember]
        [Description("结束时间")]
        public String endTime { get; set; } // 结束时间

        [DataMember]
        [Description("用户id")]
        public String userId { get; set; } //用户id

        [DataMember]
        [Description("销售订单号")]
        public String saleorderId { get; set; } // 销售订单号

        [DataMember]
        [Description("箱单id")]
        public String packId { get; set; } // 箱单id

        [DataMember]
        [Description("1为合格 0为不合格")]
        public int passed { get; set; } // 1为合格 0为不合格

        [DataMember]
        [Description("原因分类")]
        public int reasonId { get; set; } // 原因分类

        [DataMember]
        [Description("原因备注")]
        public String reasonContext { get; set; } // 原因备注

    }
}
