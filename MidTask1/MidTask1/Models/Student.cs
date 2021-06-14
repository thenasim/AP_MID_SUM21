using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidTask1.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [MaxLength(50, ErrorMessage = "Name maxlength is 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Id can't be empty")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Date of birth can't be empty")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "Credit can't be empty")]
        [Range(1, 200)]
        public double Credit { get; set; }

        [Required(ErrorMessage = "Cgpa can't be empty")]
        [Range(0, 4)]
        public double Cgpa { get; set; }

        public int DeptId { get; set; }
    }
}