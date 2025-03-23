using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace MVCandADO.Businesslogic
{
    public class Common
    {
        private static string connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["connectionString"]);

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuateQuery(string Query, SqlParameter[] param = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    connection.Close();
                }
            }
            return dt;
        }

        public int ExecuteSqlScaler(string Query, SqlParameter[] param = null)
        {
            int output = 0;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    output = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return output;
        }

        public object 
    }
}