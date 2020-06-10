using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DAL.Classes
{
    public class DbClass
    {
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader dr;
        public static DataTable dt;
        public static DataSet ds;
        public static SqlDataAdapter da;

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["sqlConnection"].ToString();
        }

        public static void OpenConnection()
        {
            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionString();
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
