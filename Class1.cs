using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace MyLiberyDataBaseAndDataGredView
{
    public class DataBase
    {
        // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=myconnection2.0;database=usersdb");
        //  public static string connectionAcsess = "Provider = Microsoft.Jet.OLED8.4.0";
        // public static string connectionAcsess = "Data Sourse=MyBase.db";

        private SQLiteConnection con = new SQLiteConnection("Data Source=MyBase.db");

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

        public SQLiteConnection getConnection()
        {
            return con;
        }

    }
}
