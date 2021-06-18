using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidTask1.Models.ViewModel
{
    public class StudentDepts
    {
        public Student Student { get; set; }
        public List<Dept> Depts { get; set; }

        public StudentDepts()
        {
            //this.Depts = new List<Dept>();
        }
    }
}