using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{

    [Serializable]
    [DataContract(Name = "PrintSetting")]
    public class PrintSetting
    {
        [DataMember(Name = "PrintSettingId")]
        [Key]
        public int PrintSettingId
        {
            get;
            set;
        }

        [DataMember(Name = "PrinterName")]
        public String PrinterName
        {
            get;
            set;
        }

        [DataMember(Name = "HorizontalOffset")]
        public int HorizontalOffset
        {
            get;
            set;
        }

        [DataMember(Name = "VerticalOffset")]
        public int VerticalOffset
        {
            get;
            set;
        }
    }
}
