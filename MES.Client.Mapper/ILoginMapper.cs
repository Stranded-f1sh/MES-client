using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Model;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
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
