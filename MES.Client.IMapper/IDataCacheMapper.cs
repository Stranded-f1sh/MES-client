using ManufacturingExecutionSystem.MES.Client.Model;
using System.Data;

namespace ManufacturingExecutionSystem.MES.Client.IMapper
{
    public interface IDataCacheMapper
    {
        int CreateTableIfNotExist();
        
        int InsertIntoDeviceCache(Device device);

        DataSet FindUnUploadData();

        int DeleteDataById(int id);

        int UpdateDataById(int id);
    }
}