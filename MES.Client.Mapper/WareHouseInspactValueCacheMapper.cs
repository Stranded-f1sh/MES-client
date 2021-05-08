using System;
using System.Data;
using System.Data.SQLite;
using ManufacturingExecutionSystem.MES.Client.IMapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    public class WareHouseInspactValueCacheMapper
    {
        public int CreateTableIfNotExist()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"CREATE TABLE
                 IF NOT EXISTS 
                    WareHouseInspactValueCache (`id` INTEGER PRIMARY KEY AUTOINCREMENT
                                 ,`imei` TEXT
                                 ,`presure` REAL
                                 , `standard_presure` REAL
                                 , `status` TEXT
                                 , `recordTime` TEXT)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }

        public int InsertIntoDeviceCache(String imei, double presure, double standard_presure, String status, String recordTime)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"INSERT INTO [WareHouseInspactValueCache]([imei]
                    , [presure]
                    , [standard_presure]
                    , [status]
                    , [RecordTime])
                    VALUES(@imei
                    , @presure
                    , @standard_presure
                    , @status
                    , @recordTime)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                SQLiteParameter pImei =
                    new SQLiteParameter("imei", DbHelper.ConvertToDbNull(imei));

                command.Parameters?.Add(pImei);

                SQLiteParameter pPresure =
                    new SQLiteParameter("presure", DbHelper.ConvertToDbNull(presure));

                command.Parameters?.Add(pPresure);

                SQLiteParameter pStandard_presure =
                    new SQLiteParameter("standard_presure", DbHelper.ConvertToDbNull(standard_presure));

                command.Parameters?.Add(pStandard_presure);

                SQLiteParameter pStatus =
                    new SQLiteParameter("status", DbHelper.ConvertToDbNull(status));
                                command.Parameters?.Add(pStatus);

                SQLiteParameter pRecordTime =
                    new SQLiteParameter("recordTime", DbHelper.ConvertToDbNull(recordTime));
                                command.Parameters?.Add(pRecordTime);

                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }


        public DataSet GroupByImei()
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                string sql = "SELECT `imei` FROM WareHouseInspactValueCache WHERE status = 'UnCommit' GROUP BY `imei`";
                SQLiteDataAdapter command = new SQLiteDataAdapter(sql, conn);
                command.Fill(ds);
                return ds;
            }
        }


        public DataSet GetValueByImei(String imei)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                string sql = "SELECT `presure`, `standard_presure` FROM WareHouseInspactValueCache WHERE imei = @imei";
                SQLiteParameter pImei = new SQLiteParameter("imei", DbHelper.ConvertToDbNull(imei));

                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                command.Parameters.Add(pImei);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                return ds;
            }
        }


        public Boolean IsDataExists(String imei, double standard_presure)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"SELECT
                            [imei]
                          , [standard_presure]
                           FROM 
                            [WareHouseInspactValueCache]
                           WHERE
                            [imei] = '"+ imei + "' " +
                           "AND [standard_presure] = '"+ standard_presure + "'";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                var reader = command.ExecuteReader();

                return reader.HasRows;
            }
        }


        public int ReplaceData(String imei, double presure, double standard_presure)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "UPDATE [WareHouseInspactValueCache] SET [presure] = @presure WHERE [imei] = @imei and [standard_presure] = @standard_presure";

                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                SQLiteParameter pPresure =
                    new SQLiteParameter("presure", DbHelper.ConvertToDbNull(presure));
                command.Parameters?.Add(pPresure);

                SQLiteParameter pImei =
                    new SQLiteParameter("imei", DbHelper.ConvertToDbNull(imei));
                command.Parameters?.Add(pImei);

                SQLiteParameter pStandard_presure =
                    new SQLiteParameter("standard_presure", DbHelper.ConvertToDbNull(standard_presure));
                command.Parameters?.Add(pStandard_presure);
                trans?.Commit();

                return command.ExecuteNonQuery();
            }
        }

        public int CommitData(String imei)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "UPDATE [WareHouseInspactValueCache] SET status = 'Committed' WHERE [imei] = @imei";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                SQLiteParameter pImei =
                    new SQLiteParameter("imei", DbHelper.ConvertToDbNull(imei));
                command.Parameters?.Add(pImei);
                trans?.Commit();

                return command.ExecuteNonQuery();
            }
        }
    }
}
