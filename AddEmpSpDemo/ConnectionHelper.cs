using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AddEmpSpDemo
{
    class ConnectionHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            string str = ConfigurationManager.ConnectionStrings["sqlPracticeCon"].ConnectionString;
            SqlConnection conn = new SqlConnection(str);
            return conn;
        }
    }
}
