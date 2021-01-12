using System;
using System.Data;
using System.Data.SQLite;
using ManufacturingExecutionSystem.MES.Client.IMapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    public class DataCacheMapper : IDataCacheMapper
    {
        public int CreateTableIfNotExist()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"CREATE TABLE
                 IF NOT EXISTS 
                    DataCache (`id` INTEGER PRIMARY KEY AUTOINCREMENT
                                 ,`imei` TEXT
                                 ,`imsi` TEXT
                                 ,`passed` INTEGER
                                 , `orderId` INTEGER
                                 , `userId` INTEGER
                                 , `processId` INTEGER
                                 , `reasonId` INTEGER
                                 , `reasonContext` TEXT
                                 , `baoGongStatus` TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }

        
        
        public int InsertIntoDeviceCache(Device device)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"INSERT INTO [DataCache]([imei]
                    , [imsi]
                    , [passed]
                    , [orderId]
                    , [userId]
                    , [processId]
                    , [reasonId]
                    , [reasonContext]
                    , [baoGongStatus])
                    VALUES(@imei
                    , @imsi
                    , @passed
                    , @orderId
                    , @userId
                    , @processId
                    , @reasonId
                    , @reasonContext
                    , @baoGongStatus)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                
                SQLiteParameter pImei =
                    new SQLiteParameter("imei", DbHelper.ConvertToDbNull(device?.Imei));

                command.Parameters?.Add(pImei);
                
                SQLiteParameter pImsi =
                    new SQLiteParameter("imsi", DbHelper.ConvertToDbNull(device?.Imsi));

                command.Parameters?.Add(pImsi);
                
                SQLiteParameter pPassed =
                    new SQLiteParameter("passed", DbHelper.ConvertToDbNull(device?.Passed));

                command.Parameters?.Add(pPassed);


                SQLiteParameter pOrderId =
                    new SQLiteParameter("orderId", DbHelper.ConvertToDbNull(device?.OrderId));

                command.Parameters?.Add(pOrderId);
                
                
                SQLiteParameter pUserId =
                    new SQLiteParameter("userId", DbHelper.ConvertToDbNull(device?.UserId));

                command.Parameters?.Add(pUserId);
                
                SQLiteParameter pProcessId =
                    new SQLiteParameter("processId", (int)DbHelper.ConvertToDbNull(device?.ProcessId));

                command.Parameters?.Add(pProcessId);
                
                SQLiteParameter pReasonId =
                    new SQLiteParameter("reasonId", DbHelper.ConvertToDbNull(device?.ReasonId));

                command.Parameters?.Add(pReasonId);
                
                SQLiteParameter pReasonContext =
                    new SQLiteParameter("reasonContext", DbHelper.ConvertToDbNull(device?.ReasonContext));

                command.Parameters?.Add(pReasonContext);
                
                SQLiteParameter pBaoGongStatus =
                    new SQLiteParameter("baoGongStatus", DbHelper.ConvertToDbNull(device?.BaoGongStatus.ToString()));

                command.Parameters?.Add(pBaoGongStatus);
                
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }



        public DataSet FindUnUploadData()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                DataSet ds = new DataSet();
                String sql = @"SELECT
                            [id]
                          , [imei]
                          , [imsi]
                          , [passed]
                          , [orderId]
                          , [userId]
                          , [processId]
                          , [reasonId]
                          , [reasonContext]
                          , [baoGongStatus]
                           FROM 
                            [DataCache]
                           WHERE
                            [baoGongStatus] = 'UnCommit'";
                SQLiteDataAdapter command = new SQLiteDataAdapter(sql, conn);
                command.Fill(ds);
                return ds;
            }
        }


        public int DeleteDataById(int id)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "DELETE FROM [DataCache] WHERE [id] = @id";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                SQLiteParameter pId =
                    new SQLiteParameter("id", DbHelper.ConvertToDbNull(id));

                command.Parameters?.Add(pId);
                trans?.Commit();

                return command.ExecuteNonQuery();
            }
        }



        public int UpdateDataById(int id)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "UPDATE [DataCache] SET [baoGongStatus] = 'Committed'  WHERE [id] = @id";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                SQLiteParameter pId =
                    new SQLiteParameter("id", DbHelper.ConvertToDbNull(id));

                command.Parameters?.Add(pId);
                trans?.Commit();

                return command.ExecuteNonQuery();
            }
        }
    }
}