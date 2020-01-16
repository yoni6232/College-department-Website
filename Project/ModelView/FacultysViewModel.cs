using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ViewModel
{
    public class FacultysViewModel
    {
        public Facultys facultyName { get; set; }
        public List<Facultys> facultysName { get; set; }
    }
}