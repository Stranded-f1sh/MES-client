using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Utility.Enum;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    [DataContract(Name = "Process")]
    public class Process
    {
        [DataMember]
        public ProcessNameEnum SelectedProcessName { get; set; }
    }
}
