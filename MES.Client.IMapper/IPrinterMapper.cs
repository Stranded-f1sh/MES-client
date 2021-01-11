using System.Data;
using ManufacturingExecutionSystem.MES.Client.Model;


namespace ManufacturingExecutionSystem.MES.Client.IMapper
{
    public interface IPrinterMapper
    {
        int CreateTableIfNotExist();

        int InsertIntoPrintSetting(PrintSetting printSetting);

        int UpdatePrintSettingById(PrintSetting printSetting);

        DataSet SelectPrinters();

        int SelectByPrinterId(PrintSetting printSetting);
    }
}
