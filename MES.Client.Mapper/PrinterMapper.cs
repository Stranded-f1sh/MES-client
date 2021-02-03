using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using ManufacturingExecutionSystem.MES.Client.IMapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    class PrinterMapper : IPrinterMapper
    {

        #region 建表

        public int CreateTableIfNotExist()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "CREATE TABLE IF NOT EXISTS printerSetting " +
                             " (`PrintSettingId` INTEGER PRIMARY KEY AUTOINCREMENT," +
                             " `PrinterName` Text," +
                             " `HorizontalOffset` Text," +
                             " `VerticalOffset` Text)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }

        #endregion


        #region 增

        public int InsertIntoPrintSetting(PrintSetting printSetting)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"INSERT INTO [printerSetting] ([PrinterName], [HorizontalOffset], [VerticalOffset])VALUES(@PrinterName, @HorizontalOffset, @VerticalOffset)";

                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                
                SQLiteParameter pPrinterName =
                    new SQLiteParameter("PrinterName", DbHelper.ConvertToDbNull(printSetting?.PrinterName));

                command.Parameters?.Add(pPrinterName);

                SQLiteParameter pHorizontalOffset =
                    new SQLiteParameter("HorizontalOffset", DbHelper.ConvertToDbNull(printSetting?.HorizontalOffset));

                command.Parameters?.Add(pHorizontalOffset);

                SQLiteParameter pVerticalOffset =
                    new SQLiteParameter("VerticalOffset", DbHelper.ConvertToDbNull(printSetting?.VerticalOffset));

                command.Parameters?.Add(pVerticalOffset);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }

        #endregion


        #region 改

        public int UpdatePrintSettingById(PrintSetting printSetting)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                try
                {
                    String sql = @"UPDATE [printerSetting]
                       SET [PrinterName] = @PrinterName
                     , [HorizontalOffset] = @HorizontalOffset
                     , [VerticalOffset] = @VerticalOffset
                       WHERE [PrintSettingId] = @PrintSettingId";
                    SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                    SQLiteParameter pPrintSettingId =
                        new SQLiteParameter("PrintSettingId", DbHelper.ConvertToDbNull(printSetting?.PrintSettingId));

                    command.Parameters?.Add(pPrintSettingId);

                    SQLiteParameter pPrinterName =
                        new SQLiteParameter("PrinterName", DbHelper.ConvertToDbNull(printSetting?.PrinterName));

                    command.Parameters?.Add(pPrinterName);

                    SQLiteParameter pHorizontalOffset =
                        new SQLiteParameter("HorizontalOffset", DbHelper.ConvertToDbNull(printSetting?.HorizontalOffset));

                    command.Parameters?.Add(pHorizontalOffset);

                    SQLiteParameter pVerticalOffset =
                        new SQLiteParameter("VerticalOffset", DbHelper.ConvertToDbNull(printSetting?.VerticalOffset));

                    command.Parameters?.Add(pVerticalOffset);

                    trans?.Commit();
                    return command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    trans?.Rollback();
                    return 0;
                }
            }
        }

        #endregion


        #region 查

        public DataSet SelectPrinters()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                DataSet ds = new DataSet();
                try
                {
                    String sql = @"SELECT 
                            [PrintSettingId]
                          , [PrinterName]
                          , [HorizontalOffset]
                          , [VerticalOffset]
                           FROM 
                            [printerSetting]";

                    // SQLiteCommand command = new SQLiteCommand(sql, conn, trans);


                    SQLiteDataAdapter command = new SQLiteDataAdapter(sql, conn);

                    command.Fill(ds);
                    return ds;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    trans?.Rollback();
                    return null;
                }
            }
        }


        public DataSet SelectByPrinterId(PrintSetting printSetting)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                DataSet ds = new DataSet();
                String sql = @"SELECT 
                            [PrintSettingId]
                          , [PrinterName]
                          , [HorizontalOffset]
                          , [VerticalOffset]
                           FROM 
                            [printerSetting] 
                           WHERE 
                            [PrintSettingId] = @PrintSettingId";

                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                SQLiteParameter pPrintSettingId = new SQLiteParameter("PrintSettingId", DbHelper.ConvertToDbNull(printSetting?.PrintSettingId));

                SQLiteDataAdapter adapter = new SQLiteDataAdapter
                {
                    SelectCommand = command
                };

                command.Parameters?.Add(pPrintSettingId);

                adapter.Fill(ds);
                return ds;
            }
        }

        #endregion
    }
}
