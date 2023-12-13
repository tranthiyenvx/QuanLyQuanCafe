using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KetNoiSQL
    {
        private static KetNoiSQL instance;

        public static KetNoiSQL Instance
        {
            get { if (instance == null) instance = new KetNoiSQL(); return KetNoiSQL.instance; }
            private set { KetNoiSQL.instance = value; }
        }
        private KetNoiSQL() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public static object ExecuteScalar(string query)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
            {
                InitialCatalog = "DB_QuanLyQuanCafe",
                DataSource = @"DESKTOP-61UVD5B\SQLEXPRESS02",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                ConnectTimeout = 0,
                MaxPoolSize = 500,
                TrustServerCertificate = true
            };
            return stringBuilder.ConnectionString;
        }
        public static DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            string conn_string = GetConnectionString();
            SqlConnection sqlConnect = new SqlConnection(conn_string);
            sqlConnect.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlConnect);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public static bool ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public static SqlDataReader getDataReader(string sql)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand(sql, connection);
                    SqlDataReader dr = com.ExecuteReader();
                    connection.Close();
                    return dr;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
