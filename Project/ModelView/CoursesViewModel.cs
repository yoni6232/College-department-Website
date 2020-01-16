using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ViewModel
{
    public class CoursesViewModel
    {
        public Courses courseName { get; set; }
        public List<Courses> coursesName { get; set; }
    }
}