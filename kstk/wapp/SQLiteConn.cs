using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using App;

namespace wapp
{
    public class SQLiteConn
    {
        public static string basePath = Application.StartupPath;

        public static string sqliteDBConn = ConfigurationManager.AppSettings["SqliteDB"];

        private static SQLiteData _sqllite;

        public static SQLiteData Sqllite
        {
            get
            {
                if (_sqllite==null)
                {
                    _sqllite = new SQLiteData();
                    string sqlconn = "data source=" + basePath + "\\" + sqliteDBConn;
                    _sqllite.ConnString = sqlconn;
                }
                return _sqllite;
            }
        }
    }
}
