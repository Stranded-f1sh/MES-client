using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    public class PrintSetting
    {
        [Key]
        public int PrintSettingId { get; set; }
        public String PrinterName { get; set; }
        public int HorizontalOffset { get; set; }
        public int VerticalOffset { get; set; }


    }
}
