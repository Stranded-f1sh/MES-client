using System;
using System.Data;
using System.Data.SQLite;
using ManufacturingExecutionSystem.MES.Client.IMapper;
using ManufacturingExecutionSystem.MES.Client.Model;
using ManufacturingExecutionSystem.MES.Client.Utility.Utils;

namespace ManufacturingExecutionSystem.MES.Client.Mapper
{
    class LoginMapper : ILoginMapper
    {
        public int CreateTableIfNotExist()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = "CREATE TABLE IF NOT EXISTS UserPassWdCache (`userId` INTEGER,`username` Text,`password` Text)";
                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }



        public int InsertIntoLoginInfo(LoginInfo loginInfo)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                String sql = @"INSERT INTO [UserPassWdCache]([userId], [username], [password])VALUES(@UserId, @username, @password)";

                SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                SQLiteParameter pUserId =
                    new SQLiteParameter("userId", DbHelper.ConvertToDbNull(loginInfo?.userId));

                command.Parameters?.Add(pUserId);

                SQLiteParameter pUsername =
                    new SQLiteParameter("username", DbHelper.ConvertToDbNull(loginInfo?.username));

                command.Parameters?.Add(pUsername);

                SQLiteParameter pPassword =
                    new SQLiteParameter("password", DbHelper.ConvertToDbNull(loginInfo?.password));

                command.Parameters?.Add(pPassword);
                trans?.Commit();
                return command.ExecuteNonQuery();
            }
        }



        public int UpdateLoginInfoById(LoginInfo loginInfo)
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                try
                {
                    String sql = @"UPDATE [UserPassWdCache]
                       SET [password] = @password
                       WHERE [userId] = @userId";
                    SQLiteCommand command = new SQLiteCommand(sql, conn, trans);

                    SQLiteParameter pUserId =
                        new SQLiteParameter("userId", DbHelper.ConvertToDbNull(loginInfo?.userId));

                    command.Parameters?.Add(pUserId);

                    SQLiteParameter pPassword =
                        new SQLiteParameter("password", DbHelper.ConvertToDbNull(loginInfo?.password));

                    command.Parameters?.Add(pPassword);

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



        public DataSet SelectLoginInfo()
        {
            using (SQLiteConnection conn = DbHelper.GetConnection(out SQLiteTransaction trans))
            {
                DataSet ds = new DataSet();
                try
                {
                    String sql = @"SELECT 
                            [userId]
                          , [username]
                          , [password]
                           FROM 
                            [UserPassWdCache]";

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

        public int SelectByUserId(LoginInfo loginInfo)
        {
            throw new NotImplementedException();
        }
    }
}
