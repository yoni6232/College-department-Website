using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ViewModel
{
    public class StudentViewModel
    {
        public Student studentName { get; set; }
        public List<Student> studentsName { get; set; }
    }
}