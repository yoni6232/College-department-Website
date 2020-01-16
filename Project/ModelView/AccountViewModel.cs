using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ViewModel
{
    public class AccountViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "sadsa")]
        public Account userName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "sadsa")]
        public List<Account> usersName { get; set; }
    }
}