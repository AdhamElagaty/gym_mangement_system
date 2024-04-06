using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system.Service
{
    public class SqlService
    {
        private static string path = Path.GetFullPath(Environment.CurrentDirectory);
        private static string database = "pulseup_gym_management_system.mdf";
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + database + ";Integrated Security=True";

        public static string ConnectionString { get { return connectionString; } }
        public SqlConnection connection = new SqlConnection(ConnectionString);

        public SqlDataReader SqlSelect(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand slct = new SqlCommand(query, connection);
            connection.Open();
            Console.WriteLine(connection);
            SqlDataReader reader = slct.ExecuteReader();
            Console.WriteLine(reader.ToString());
            return reader;
        }
        public int sqlExecuteScalar(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            object result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
        public int SqlNonQuery(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
