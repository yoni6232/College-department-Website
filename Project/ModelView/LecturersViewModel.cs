﻿using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.ViewModel
{
    public class LecturesViewModel
    {
        public Lectures lectureName { get; set; }
        public List<Lectures> lecturesName { get; set; }
    }
}