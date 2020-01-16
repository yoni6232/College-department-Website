using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Editcourse
    {
        [Required]
        public string studentName  { get; set; }
        [Required]
        public string studentlastName { get; set; }
        [Required]
        public int StudentID { get; set; }
        public int LectureID { get; set; }
        [Required]
        public int GradeA { get; set; }
        public int GradeB { get; set; }
        public List<Editcourse> editcourses2 { get; set; }

        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string Coursename { get; set; }

    }
}