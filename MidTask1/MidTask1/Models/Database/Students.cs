using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MidTask1.Models.Database
{
    public class Students
    {
        readonly SqlConnection conn;

        public Students(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Insert(Student s)
        {
            string query = "INSERT INTO Students VALUES(@name, @id, @dob, @credit, @cgpa, @dept_id)";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@id", s.Id);
            cmd.Parameters.AddWithValue("@dob", s.Dob);
            cmd.Parameters.AddWithValue("@credit", s.Credit);
            cmd.Parameters.AddWithValue("@cgpa", s.Cgpa);
            cmd.Parameters.AddWithValue("@dept_id", 1); // Added hard coded value in dept id

            this.conn.Open();
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }

        public Student Get(int id)
        {
            Student s = null;
            string query = $"SELECT * FROM Students WHERE StudentId={id}";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            this.conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                s = new Student()
                {
                    StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                    Name = rdr.GetString(rdr.GetOrdinal("Name")),
                    Id = rdr.GetString(rdr.GetOrdinal("Id")),
                    Dob = rdr.GetString(rdr.GetOrdinal("Dob")),
                    Credit = rdr.GetDouble(rdr.GetOrdinal("Credit")),
                    Cgpa = rdr.GetDouble(rdr.GetOrdinal("Cgpa")),
                    DeptId = rdr.GetInt32(rdr.GetOrdinal("DeptId"))
                };
            }

            return s;
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, this.conn);

            this.conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                Student s = new Student()
                {
                    StudentId = rdr.GetInt32(rdr.GetOrdinal("StudentId")),
                    Name = rdr.GetString(rdr.GetOrdinal("Name")),
                    Id = rdr.GetString(rdr.GetOrdinal("Id")),
                    Dob = rdr.GetString(rdr.GetOrdinal("Dob")),
                    Credit = rdr.GetDouble(rdr.GetOrdinal("Credit")),
                    Cgpa = rdr.GetDouble(rdr.GetOrdinal("Cgpa")),
                    DeptId = rdr.GetInt32(rdr.GetOrdinal("DeptId"))
                };
                students.Add(s);
            }

            this.conn.Close();
            return students;
        }

        public void Update(Student s)
        {
            // Removed dept id from query string
            string query = $"UPDATE Students Set Name=@name, Id=@id, Dob=@dob, Credit=@credit, Cgpa=@cgpa WHERE StudentId={s.StudentId}";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            cmd.Parameters.AddWithValue("@name", s.Name);
            cmd.Parameters.AddWithValue("@id", s.Id);
            cmd.Parameters.AddWithValue("@dob", s.Dob);
            cmd.Parameters.AddWithValue("@credit", s.Credit);
            cmd.Parameters.AddWithValue("@cgpa", s.Cgpa);

            this.conn.Open();
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }

        public void Delete(int id)
        {
            string query = $"DELETE FROM Students WHERE StudentId={id}";
            SqlCommand cmd = new SqlCommand(query, this.conn);
            this.conn.Open();
            cmd.ExecuteNonQuery();
            this.conn.Close();
        }
    }
}