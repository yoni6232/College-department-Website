using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
namespace Project.Controllers
{
    public class AccountController : Controller
    {
        public string utype;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Exams()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source =ANGELS-LAPTOP;database = Project; integrated security = SSPI";
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            SqlDataAdapter sda = new SqlDataAdapter("select userType from Users where userName='" + acc.Name + "'and userPassword='" + acc.Password + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                utype = dt.Rows[0][0].ToString().Trim();
                if (utype == "student")
                {
                    con.Close();
                    return View("StudentHomePage");
                }
                else if (utype == "lecturer")
                {
                    con.Close();
                    return View("LecturerHomePage");
                   
                }
                else if (utype == "faculty")
                {
                    con.Close();
                    return View("FacultyHomePage");
                }
                else
                {
                    con.Close();
                    return View("Error");
                }
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
        }
    }
}