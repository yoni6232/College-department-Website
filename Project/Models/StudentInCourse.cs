using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class StudentInCourse

    {

        [Key]
        [Required]
        public int studentID { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public int GradeA { get; set; }
        public int GradeB { get; set; }


        public virtual Student Student { get; set; }

        public virtual Courses Course { get; set; }

    }
}