using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MidTask1.Models.Database
{
    public class Database
    {
        public Admins Admins { get; set; }
        public Students Students { get; set; }
        public Depts Depts { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-0CQM2ED;Database=ATPMIDTASK1;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connString);

            this.Admins = new Admins(conn);
            this.Students = new Students(conn);
            this.Depts = new Depts(conn);
        }
    }
}