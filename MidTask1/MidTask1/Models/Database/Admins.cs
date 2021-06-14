using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MidTask1.Models.Database
{
    public class Admins
    {
        readonly SqlConnection conn;
        public Admins(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool Login(Admin a)
        {
            string query = $"SELECT * FROM Admins WHERE Username='{a.Username}' AND Password='{a.Password}'";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            this.conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            bool result = rdr.HasRows;
            this.conn.Close();

            return result;
        }
    }
}