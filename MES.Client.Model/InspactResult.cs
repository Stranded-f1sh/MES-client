using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "InspactResult")]
    public class InspactResult
    {
        [DataMember]
        [Description("设备号")]
        public String imei { get; set; } 


        [DataMember]
        [Description("上行程1")]
        public float value1 { get; set; } 

        [DataMember]
        [Description("上行程2")]
        public float value2 { get; set; } 

        [DataMember]
        [Description("上行程3")]
        public float value3 { get; set; }

        [DataMember]
        [Description("上行程4")]
        public float value4 { get; set; }

        [DataMember]
        [Description("上行程5")]
        public float value5 { get; set; }

        [DataMember]
        [Description("下行程4")]
        public float value6 { get; set; }

        [DataMember]
        [Description("下行程3")]
        public float value7 { get; set; }

        [DataMember]
        [Description("下行程2")]
        public float value8 { get; set; }

        [DataMember]
        [Description("下行程1")]
        public float value9 { get; set; }

        [DataMember]
        [Description("updatetime")]
        public string updatetime { get; set; }
    }
}
