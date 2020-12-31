using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Model;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    class PrinterMapper : IPrinterMapper
    {
        public PrinterSettings SelectByPrinterId(int printerId)
        {
            using (PrinterContext db = new PrinterContext())
            {
                //db.PrintSettings?.SqlQuery("SELECT ")
            }

            return null;
        }
    }
}
