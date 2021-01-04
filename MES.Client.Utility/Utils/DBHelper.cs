using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    public class DbHelper
    {
        public static SQLiteConnection GetConnection(out SQLiteTransaction trans)
        {
            SQLiteConnection conn = new SQLiteConnection(ConfigurationManager.AppSettings["connectionStrings"]);
            conn.Open();
            trans = conn.BeginTransaction();
            return conn;
        }


        public static object ConvertToDbNull(object obj)
        {
            if (obj == null || (obj is DateTime time && DateTime.MinValue == time))
            {
                return Convert.DBNull;
            }

            return obj;
        }
    }
}
