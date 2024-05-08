using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Grocery_Store.Data_Access_Objects
{
    public class Connection
    {
        string connectionString = @"data source=DELL\SQLEXPRESS;initial catalog=OnlineGroceryStore;integrated security=true;";
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}