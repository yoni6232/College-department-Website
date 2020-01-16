using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Dal
{
    public class EditcourseDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Editcourse>().ToTable("Editcourse");

        }
        public DbSet<Editcourse> editcourses { get; set; }

    }
}