using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int studentID { get; set; }

        [Required]
        public string studentName { get; set; }

        [Required]
        public string studentLastName { get; set; }

    }
}