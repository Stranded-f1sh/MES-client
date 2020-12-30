using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "Qualify")]
    class Qualify
    {
        [DataMember]
        [Description("ReasonId")]
        public int Id { get; set; } // 不合格原因id

        [DataMember]
        [Description("Reason")]
        public String Reason { get; set; } // 不合格原因
    }
}
