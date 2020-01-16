using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Courses
    {
        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int LectureID { get; set; }


        public string Coursename { get; set; }

        public TimeSpan? ExamHour { get; set; }

        public string ExamDay { get; set; }

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
        public List<Courses> info { get; set; }


    }
}
