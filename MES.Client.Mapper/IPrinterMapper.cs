using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    public interface IPrinterMapper
    {
        PrinterSettings SelectByPrinterId(int printerId);
    }
}
