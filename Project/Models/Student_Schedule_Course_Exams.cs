using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Student_Schedule_Course_Exam

    {

        [Required]
        public int StudentID { get; set; }
        [Required]
        public string LecName { get; set; }
        [Required]
        public string LecLastName { get; set; }
        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public TimeSpan StartHour { get; set; }
        [Required]
        public TimeSpan EndHour { get; set; }
        [Required]
        public int? moedAYear { get; set; }
        public int? moedAMonth { get; set; }
        public int? moedADay { get; set; }
        [Required]
        public int? moedBYear { get; set; }
        public int? moedBMonth { get; set; }
        public int? moedBDay { get; set; }
        [Required]
        public string moedAClass { get; set; }
        [Required]
        public string moedBClass { get; set; }

        public int? GradeA { get; set; }
        public int? GradeB { get; set; }
        [Required]
        public DateTime? ExamHour { get; set; }
        [Required]
        public string ExamDay { get; set; }
    }
}