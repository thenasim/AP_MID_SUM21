using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MidTask1.Models.Database
{
    public class Depts
    {
        readonly SqlConnection conn;

        public Depts(SqlConnection conn)
        {
            this.conn = conn;
        }

        public Dept Get(int id)
        {
            Dept d = null;
            string query = $"SELECT * FROM Depts WHERE DeptId={id}";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            this.conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                d = new Dept()
                {
                    DeptId = rdr.GetInt32(rdr.GetOrdinal("DeptId")),
                    Name = rdr.GetString(rdr.GetOrdinal("Name")),
                };
            }

            this.conn.Close();
            return d;
        }

        public List<Dept> GetAll()
        {
            List<Dept> depts = new List<Dept>();
            string query = "SELECT * FROM Depts";
            SqlCommand cmd = new SqlCommand(query, this.conn);

            this.conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                Dept d = new Dept()
                {
                    DeptId = rdr.GetInt32(rdr.GetOrdinal("DeptId")),
                    Name = rdr.GetString(rdr.GetOrdinal("Name")),
                };
                depts.Add(d);
            }

            this.conn.Close();
            return depts;
        }
    }
}