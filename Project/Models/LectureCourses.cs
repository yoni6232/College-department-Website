using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class LectureCourses
    {
        [Required]
        public int LecID { get; set; }
        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string Coursename { get; set; }
        [Required]
        public TimeSpan StartHour { get; set; }
        [Required]
        public TimeSpan EndHour { get; set; }

        [Required]
        public string Day { get; set; }
    }
}