using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int userID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string userPassword { get; set; }
        [Required]
        public string userType { get; set; }

    }

}