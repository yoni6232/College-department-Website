using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Project.Models;
using System.Configuration;
using Project.Dal;
using System.Web.UI;
using Project.Controllers;
using System.Text;

namespace Project.Controllers
{

    public class LecturerController : Controller
    {

        public ActionResult AddGrade(Editcourse editcourses2)
        {
            var studentid = Request.Form["StudentID"];
            SqlConnection con1 = new SqlConnection(@"data source=DESKTOP-O9SQCAH;database=ProjectFinal; Integrated Security=SSPI");
            con1.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select StudentID from [Students] where StudentID ='" + studentid + "'", con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {

                @Session["check"] = "opertion faild student";
                return View("Editcourse");
                con1.Close();
            }
            con1.Close();
            bool check = false;
            if (Request.Form["GradeA"] != "")
            {

                var gradeA = Request.Form["GradeA"];
 
                SqlConnection con = new SqlConnection();

                con.ConnectionString = "data source = DESKTOP-O9SQCAH;database = ProjectFinal; integrated security = true";
          
                con.Open();

                SqlCommand sqlcomm = new SqlCommand();
                sqlcomm.CommandText = "update [dbo].[Editcourse] set GradeA = '" + gradeA + "' where StudentID = '" + studentid + "'and CourseID = '" + @Session["CourseID"] + "'";
                sqlcomm.Connection = con;
                sqlcomm.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Editcourse", editcourses2);

            }
                else if (Request.Form["GradeB"] != "")

            {


                var gradeB = Request.Form["Gradeb"];
                 
                   SqlConnection con = new SqlConnection();

                    con.ConnectionString = "data source = DESKTOP-O9SQCAH;database = ProjectFinal; integrated security = true";
                    con.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    sqlcomm.CommandText = "update [dbo].[Editcourse] set GradeB = '" + gradeB + "' where StudentID = '" + studentid + "'and CourseID = '" + @Session["CourseID"] + "'";
                    sqlcomm.Connection = con;
                    sqlcomm.ExecuteNonQuery();
                    con.Close();
                     return RedirectToAction("Editcourse", editcourses2);

            }
            else
            {
                @Session["check"] = "opertion faild not A or B";
                return View("Editcourse");
            }
        }
    


        public ActionResult Editcourse(Editcourse editcourses2)
        {
            string courseid;
            if (Request.Form["CourseID"] == null)
            {
                 courseid = @Session["CourseID"].ToString();
            }
            else {
                 courseid = Request.Form["CourseID"];
        }

            int coursesid = Convert.ToInt32(courseid);
            Session["CourseID"] = courseid;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-O9SQCAH;database = ProjectFinal; integrated security = SSPI";
            SqlCommand sqlcomm = new SqlCommand(@"select * from [dbo].[Editcourse] where CourseID='" + coursesid + "'", con);
            sqlcomm.Connection = con;
            con.Open();
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            List<Editcourse> objmodel = new List<Editcourse>();
            if (sdr.HasRows)
            {
                @Session["check"] = "opertion";

                while (sdr.Read())
                {
                    var details = new Editcourse();
                    details.studentName = sdr["studentName"].ToString();
                    details.studentlastName = sdr["studentlastName"].ToString();
                    details.StudentID = Convert.ToInt32(sdr["StudentID"]);
                    details.GradeA = (sdr["GradeA"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["GradeA"]);
                    details.GradeB = (sdr["GradeB"] == DBNull.Value) ? 0 : Convert.ToInt32(sdr["GradeB"]);
                    details.CourseID = coursesid;
                    details.Coursename = sdr["Coursename"].ToString();


                    objmodel.Add(details);

                }
                editcourses2.editcourses2 = objmodel;
                con.Close();
                return View("Editcourse", editcourses2);


            }

            else 
                {
                    @Session["check"] = "opertion faild course";
                    return RedirectToAction("LecturerCourse");


            }

        }

        public ActionResult LecturerCourse()
        {
            var id = (int)Session["ID"];
            LectureCoursesDal LCD = new LectureCoursesDal();
            List<LectureCourses> courseinfo = (from x in LCD.lecturescourses where x.LecID.Equals(id) select x).ToList<LectureCourses>();
            ViewBag.coursesinfo = courseinfo;
            return View("LecturerCourse");
        }

        public ActionResult LecturerSchedule()
        {
            var id = (int)Session["ID"];
            LectureCoursesDal LCD = new LectureCoursesDal();
            List<LectureCourses> courseinfo = (from x in LCD.lecturescourses where x.LecID.Equals(id) select x).ToList<LectureCourses>();
            ViewBag.coursesinfo = courseinfo;
            return View("LecturerSchedule");
        }
        public ActionResult LecturerExams()
        {
            var id = (int)Session["ID"];
            LectureCoursesDal LCD = new LectureCoursesDal();
            List<LectureCourses> courseinfo = (from x in LCD.lecturescourses where x.LecID.Equals(id) select x).ToList<LectureCourses>();
            ViewBag.coursesinfo = courseinfo;
            return View("LecturerExams");
        }
    }

}