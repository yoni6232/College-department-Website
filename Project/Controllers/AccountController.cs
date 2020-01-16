using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Controllers;
using Project.ViewModel;
using Project.Dal;

namespace Project.Controllers
{
    public class AccountController : Controller
    {

        //[HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult StudentHomePage()
        {
            @Session["check"] = "opertion ";

            return View("StudentHomePage");
        }
        public ActionResult FacultyHomePage()
        {
            @Session["check"] = "opertion ";

            return View("FacultyHomePage");
        }
        public ActionResult LecturerHomePage()
        {
            @Session["check"] = "opertion ";

            return View("LecturerHomePage");
        }
        public ActionResult Verify()
        {
            if (ModelState.IsValid)
            {
                AccountDal dal = new AccountDal();
                string username = Request.Form["Name"].ToString();
                string userpassword = Request.Form["Password"].ToString();
                List<Account> acc = (from x in dal.Users where x.userName == username && x.userPassword == userpassword select x).ToList<Account>();
                AccountViewModel usr = new AccountViewModel();
                bool check = false;
                usr.usersName = acc;
                if (usr.usersName.Count == 0)
                {
                    Session["check"] = "opertion faild name";
                    return RedirectToAction("Login");
                }
                else
                {
                    Session["check"] = "opertion";
                    Account login_usr = new Account();
                    login_usr = usr.usersName[0];
                    Session["Username"] = login_usr.userName;
                    Session["Password"] = login_usr.userPassword;
                    Session["Type"] = login_usr.userType;
                    Session["ID"] = login_usr.userID;

                    if (login_usr.userType == "student")
                    {

                        return View("StudentHomePage", login_usr);
                    }
                    if (login_usr.userType == "faculty")
                    {
                        return View("FacultyHomePage", login_usr);
                    }
                    if (login_usr.userType == "lecturer")
                    {
                        return View("LecturerHomePage", login_usr);
                    }
                    else
                    {
                        return View("Login");

                    }
                }



            }
            else
            {
                return View("Login");

            }


        }
    }
}