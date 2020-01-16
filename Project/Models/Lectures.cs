using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Lectures
    {
        [Key]
        [Required]
        public int LecID { get; set; }

        [Required]
        public string LecName { get; set; }

        [Required]
        public string LecLastName { get; set; }

    }
}