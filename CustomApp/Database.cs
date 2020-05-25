using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomApp
{
    class Database
    {
        public static MySqlConnection con = null;
        public Database(string connectionString)
        {
            //Create a new instance of a MySQL connection with given connection string
            con = new MySqlConnection(connectionString);
            con.Open();
        }
    }
}
