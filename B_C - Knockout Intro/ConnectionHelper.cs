using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace B_C___Knockout_Intro
{
    public static class ConnectionHelper
    {
        public static T WithNewConnection<T>(Func<DbConnection, T> Code)
        {
            string connStr = "server=localhost;user=jjnguy;database=world;port=3307;password=asdf1234;";
            DbConnection con = new MySqlConnection(connStr);
            con.ConnectionString = connStr;
            con.Open();

            var result = Code(con);

            con.Close();

            return result;
        }
        public static void WithNewConnection(Action<DbConnection> Code)
        {
            string connStr = "server=localhost;user=jjnguy;database=world;port=3307;password=asdf1234;";
            DbConnection con = new MySqlConnection(connStr);
            con.ConnectionString = connStr;
            con.Open();

            Code(con);

            con.Close();
        }
    }
}