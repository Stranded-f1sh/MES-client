using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Model
{
    internal class PrinterContext : DbContext
    {
        public PrinterContext() : base("name=ManufacturingExecutionSystem.Properties.Settings.MesSqlServerDataBaseConnectionString")
        {
            Database.SetInitializer<PrinterContext>(null);
        }

        public DbSet<PrintSetting> PrintSettings { get; set; }
    }
}
