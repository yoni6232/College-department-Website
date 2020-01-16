using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Dal
{
    public class LectureCoursesDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LectureCourses>().ToTable("LectureCourses");
        }
        public DbSet<LectureCourses> lecturescourses { get; set; }
    }
}