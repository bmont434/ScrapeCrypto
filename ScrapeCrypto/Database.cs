using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ScrapeCrypto
{
    class Database
    {
        public void DbConnect(string query1, string query2)
        {
            string connectionString = @"Data Source=DESKTOP-NQBHKAV\SQLEXPRESS;Initial Catalog=Crypto;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand Eth = new SqlCommand(query1, conn);
            SqlCommand Bit = new SqlCommand(query2, conn);
            conn.Open();
            Eth.ExecuteNonQuery();
            Bit.ExecuteNonQuery();
            conn.Close();
        }
    }
}
