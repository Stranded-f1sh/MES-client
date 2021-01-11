using System.Data;
using ManufacturingExecutionSystem.MES.Client.Model;

namespace ManufacturingExecutionSystem.MES.Client.IMapper
{
    public interface ILoginMapper
    {
        int CreateTableIfNotExist();
        int InsertIntoLoginInfo(LoginInfo loginInfo);
        int UpdateLoginInfoById(LoginInfo loginInfo);
        DataSet SelectLoginInfo();
        int SelectByUserId(LoginInfo loginInfo);
    }
}
