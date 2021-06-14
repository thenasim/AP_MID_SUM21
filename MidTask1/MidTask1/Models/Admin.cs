using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidTask1.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }
    }
}