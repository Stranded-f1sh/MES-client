using ManufacturingExecutionSystem.MES.Client.Model;

namespace ManufacturingExecutionSystem.MES.Client.IMapper
{
    public interface IBaoGongCacheMapper
    {
        int CreateTableIfNotExist();
        
        int InsertIntoDeviceCache(Device device);
        
        
    }
}