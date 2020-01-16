using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Dal
{
    public class Student_Schedule_Course_ExamsDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student_Schedule_Course_Exam>().ToTable("Student_Schedule_Course_Exam");
        }
        public DbSet<Student_Schedule_Course_Exam> students_schedule_course_exams { get; set; }
    }
}