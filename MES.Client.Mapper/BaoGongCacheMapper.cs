using System;
using System.Data.SQLite;
using ManufacturingExecutionSystem.MES.Client.IMapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    public class BaoGongCacheMapper : IBaoGongCacheMapper
    {
        public int CreateTableIfNotExist()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"CREATE TABLE
                 IF NOT EXISTS 
                    BaoGongCache (`imei` TEXT
                                 ,`imsi` TEXT
                                 ,`passed` INTEGER
                                 , `orderId` INTEGER
                                 , `userId` INTEGER
                                 , `processId` INTEGER
                                 , `reasonId` INTEGER
                                 , `reasonContext` TEXT
                                 , `submitStatus` TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }

        public int InsertIntoDeviceCache(Device device)
        {
            throw new System.NotImplementedException();
        }
    }
}