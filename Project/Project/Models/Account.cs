using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }
    }
}