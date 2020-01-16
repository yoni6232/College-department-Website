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

namespace Project.Controllers
{
    public class FacultysController : Controller
    {
        public ActionResult Student(Courses c)
        {
            var studentid = Request.Form["StudentID"];

            if (Request.Form["Studentid"] != null && Request.Form["CourseId"] != null)
            {

                int Studentid = Int32.Parse(Request.Form["Studentid"]);
                string CourseId = Request.Form["CourseId"].ToString();

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH;database=ProjectFinal;Integrated Security=SSPI");

                SqlCommand sda3 = new SqlCommand("select StudentID,CourseID from Courses,students where StudentID ='" + Studentid + "' and CourseID ='" + CourseId + "'", con);

                sda3.Connection = con;
                con.Open();
                SqlDataReader sdr1 = sda3.ExecuteReader();

                if (!sdr1.HasRows)
                {
                    Session["check"] = "opertion faild course";
                    return View();
                }
                con.Close();



                    SqlDataAdapter sda = new SqlDataAdapter("select StudentID,CourseID from [StudentInCourse] where StudentID ='" + Studentid + "' and CourseID ='" + CourseId + "'", con);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    @Session["check"] = "opertion faild exsit";
                   return View();                
                }
       
                else
                    {
                    SqlCommand sda1 = new SqlCommand("select day,StartHour,EndHour from Courses where CourseID ='" + CourseId + "'", con);

                    sda1.Connection = con;
                    con.Open();
                    SqlDataReader sdr = sda1.ExecuteReader();

                    List<Courses> objmodel = new List<Courses>();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            var details = new Courses();
                            details.Day = sdr["day"].ToString();
                            details.StartHour = TimeSpan.Parse(sdr["StartHour"].ToString());
                            details.EndHour = TimeSpan.Parse(sdr["EndHour"].ToString());
                            objmodel.Add(details);

                        }
                        c.info = objmodel;
                        con.Close();

                    }
                        else
                        {
                            Session["check"] = "opertion faild course";
                                 return View();
                        }
                     if (!CheckCoursesStu(c, Studentid, c.CourseID, c.info[0].Day, c.info[0].StartHour, c.info[0].EndHour))
                        {
                            Session["check"] = "opertion faild hour";
                            return View();
                         }

                    else 
                    {
                         @Session["check"] = "opertion succesed";

                        SqlCommand sda2 = new SqlCommand(@"INSERT INTO [StudentInCourse] (StudentID, CourseID) VALUES ('" + Studentid + "', '" + CourseId + "')", con);
                        SqlDataAdapter da = new SqlDataAdapter(sda2);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                         return View();
                    }
                }
            }
            return View();
        }

        public ActionResult FacultyAddCourse(Courses c)
        {
            if (Request.Form["CourseId"] != null && Request.Form["CourseName"] != null && Request.Form["LecturerId"] != null && Request.Form["Day"] != null && Request.Form["StartHour"] != null && Request.Form["EndHour"] != null
                && Request.Form["MoedADay"] != null && Request.Form["MoedAMonth"] != null && Request.Form["MoedAYear"] != null && Request.Form["MoedBDay"] != null && Request.Form["MoedBMonth"] != null && Request.Form["MoedBYear"] != null && Request.Form["MoedAClass"] != null && Request.Form["MoedBClass"] != null)
            {
                int CourseId = Int32.Parse(Request.Form["CourseId"]);
                string CourseName = Request.Form["CourseName"].ToString();
                int LecturerId = Int32.Parse(Request.Form["LecturerId"]);
                string Day = Request.Form["Day"].ToString();
                TimeSpan StartHour = TimeSpan.Parse(Request.Form["StartHour"].ToString());
                TimeSpan EndHour = TimeSpan.Parse(Request.Form["EndHour"].ToString());
                int MoedADay = Int32.Parse(Request.Form["moedADay"]);
                int MoedAMonth = Int32.Parse(Request.Form["moedAMonth"]);
                int MoedAYear = Int32.Parse(Request.Form["moedAYear"]);
                int MoedBDay = Int32.Parse(Request.Form["moedBDay"]);
                int MoedBMonth = Int32.Parse(Request.Form["moedBMonth"]);
                int MoedBYear = Int32.Parse(Request.Form["moedBYear"]);
                string MoedAClass = Request.Form["MoedAClass"].ToString();
                string MoedBClass = Request.Form["MoedBClass"].ToString();
                SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH;database=ProjectFinal;Integrated Security=SSPI");
                SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH;database=ProjectFinal;Integrated Security=SSPI");

                SqlCommand sda3 = new SqlCommand("select LecID from lectures where LecID ='" + LecturerId + "'", con1);
                SqlCommand sda4 = new SqlCommand("select CourseID from Courses where CourseID ='" + CourseId + "'", con2);
                sda4.Connection = con1;
                sda3.Connection = con2;
                con1.Open();
                con2.Open();
                SqlDataReader sdr1 = sda3.ExecuteReader();
                SqlDataReader sdr2 = sda4.ExecuteReader();
                if (sdr2.HasRows)
                {
                    Session["check"] = "opertion faild course";
                    return View();
                }
                if (!sdr1.HasRows)
                {
                    Session["check"] = "opertion faild lec";
                    return View();
                }
                con1.Close();
                con2.Close();

                if (!CheckCoursesLec(c, LecturerId, CourseId, Day, StartHour, EndHour))
                {
                    Session["check"] = "opertion faild hour";
                    return View();
                }
                else
                {

                    @Session["check"] = "opertion succesed";
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH; database = ProjectFinal;Integrated Security=SSPI");
                    SqlCommand sda1 = new SqlCommand(@"INSERT INTO [Courses] (CourseID, Coursename ,LectureID, Day,StartHour,EndHour,moedAYear,moedAMonth,moedADay,moedAClass,moedBYear,moedBMonth,moedBDay,moedBClass) VALUES ('" + CourseId + "', '" + CourseName + "', '" + LecturerId + "', '" + Day + "', '" + StartHour + "', '" + EndHour + "', '" + MoedAYear + "', '" + MoedAMonth + "', '" + MoedADay + "', '" + MoedAClass + "', '" + MoedBYear + "', '" + MoedBMonth + "', '" + MoedBDay + "', '" + MoedBClass + "')", con);
                    SqlDataAdapter da = new SqlDataAdapter(sda1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                }

            }

            return View("FacultyAddCourse");
        }

        public ActionResult AddGrade(Editcourse editcourses2)
        {
            var studentid = Request.Form["StudentID"];

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
    
        public ActionResult FacultyUpdateExamsSchedule()
        {

            if (Request.Form["CourseIdTB"] != null && Request.Form["moedADay"] != null && Request.Form["moedAMonth"] != null && Request.Form["moedAYear"] != null)
            {
                int CourseId = Int32.Parse(Request.Form["CourseIdTB"]);
                int MoedADay = Int32.Parse(Request.Form["moedADay"]);
                int MoedAMonth = Int32.Parse(Request.Form["moedAMonth"]);
                int MoedAYear = Int32.Parse(Request.Form["moedAYear"]);
                SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH;database=ProjectFinal;Integrated Security=SSPI");

                SqlCommand sda4 = new SqlCommand("select CourseID from Courses where CourseID ='" + CourseId + "'", con1);
                sda4.Connection = con1;
                con1.Open();
                SqlDataReader sdr2 = sda4.ExecuteReader();
                if (!sdr2.HasRows)
                {
                    Session["check"] = "opertion faild course";
                    return View();
                }
                con1.Close();
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-O9SQCAH;database=ProjectFinal; Integrated Security=SSPI");
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select CourseID from [Courses] where CourseID ='" + CourseId + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    SqlCommand sqlcomm = new SqlCommand();
                    sqlcomm.CommandText = "update [Courses] set moedAYear = '" + MoedAYear + "', moedAMonth='" + MoedAMonth + "', moedADay='" + MoedADay + "' where CourseId ='" + CourseId + "'";
                    sqlcomm.Connection = con;
                    sqlcomm.ExecuteNonQuery();

                    con.Close();
                }
            }
            else if (Request.Form["CourseIdTB"] != null && Request.Form["moedBDay"] != null && Request.Form["moedBMonth"] != null && Request.Form["moedBYear"] != null)
            {
                int CourseId = Int32.Parse(Request.Form["CourseIdTB"]);
                int MoedBDay = Int32.Parse(Request.Form["moedBDay"]);
                int MoedBMonth = Int32.Parse(Request.Form["moedBMonth"]);
                int MoedBYear = Int32.Parse(Request.Form["moedBYear"]);

                SqlConnection con = new SqlConnection(@"data source =DESKTOP-O9SQCAH;database = ProjectFinal;Integrated Security=SSPI");
                SqlDataAdapter sda = new SqlDataAdapter("select CourseID from [Courses] where CourseID ='" + CourseId + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    con.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    sqlcomm.CommandText = "update [Courses] set moedBYear = '" + MoedBYear + "', moedBMonth='" + MoedBMonth + "', moedBDay='" + MoedBDay + "' where CourseId ='" + CourseId + "'";
                    sqlcomm.Connection = con;
                    sqlcomm.ExecuteNonQuery();

                    con.Close();
                }
            }
            else
            {

                //message box "The course not exist!

            }
            return View("FacultyUpdateExamsSchedule");
        }

        public ActionResult Editcourse(Editcourse editcourses2)
        {
            string courseid;
            if (Request.Form["CourseID"] == null)
            {
                courseid = @Session["CourseID"].ToString();
            }
            else
            {
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
                return RedirectToAction("Course");


            }

        }

        public ActionResult Course()
        {

            return View();
        }

        public ActionResult Register()
        {
            int id = (int)Session["ID"];
         
            if (Request.Form["UserID"] != null && Request.Form["username"] != null && Request.Form["password"] != null)
            {
                int UserId = Int32.Parse(Request.Form["userID"]);
                string UserName = Request.Form["username"].ToString();
                string Password = Request.Form["password"].ToString();
                string UserType = Request.Form["type"].ToString();

                string FirstName = Request.Form["FirstName"].ToString();
                string LastName = Request.Form["LastName"].ToString();
                bool check = false;
                SqlConnection con = new SqlConnection(@"data source =DESKTOP-O9SQCAH; database = ProjectFinal; integrated security = true");
                SqlDataAdapter sda = new SqlDataAdapter("select userID from [Users] where userID ='" + UserId + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (UserType != "student" && UserType != "lecturer" && UserType != "faculty")
                {
                    Session["check"] = "opertion faild type";
                    return View("Register");
                }
                if (dt.Rows.Count == 1)
                {
                    Session["check"] = "opertion faild id";
                    return View("Register");
                }
                else
                {
                    @Session["check"] = "opertion sucessed";
                    @Session["new"] = UserName;
                    //insert into User Table
                    SqlCommand sda1 = new SqlCommand(@"INSERT INTO [Users] (userID, userName, userPassword, userType) VALUES ('" + UserId + "', '" + UserName + "', '" + Password + "', '" + UserType + "')", con);
                    SqlDataAdapter da = new SqlDataAdapter(sda1);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (UserType == "student")
                    {
                        //insert Student into Student Table
                        SqlCommand sda2 = new SqlCommand(@"INSERT INTO [Students] (StudentID, studentName, studentlastName) VALUES ('" + UserId + "', '" + FirstName + "', '" + LastName + "')", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(sda2);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        ViewBag.Message = string.Format("New Student has been added").ToString();

                    }
                    if (UserType == "lecturer")
                    {
                        //insert lecturer into Student Table
                        SqlCommand sda2 = new SqlCommand(@"INSERT INTO [Lectures] (LecID, LecName, LeclastName) VALUES ('" + UserId + "', '" + FirstName + "', '" + LastName + "')", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(sda2);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        ViewBag.Message = string.Format("New Lecturer has been added").ToString();

                    }
                    if (UserType == "faculty")
                    {
                        //insert faculty into Student Table
                        SqlCommand sda2 = new SqlCommand(@"INSERT INTO [Facultys] (FacultyID, facfirstName, faclastName) VALUES ('" + UserId + "', '" + FirstName + "', '" + LastName + "')", con);
                        SqlDataAdapter da1 = new SqlDataAdapter(sda2);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                        ViewBag.Message = string.Format("New Faculty has been added").ToString();

                    }

                    con.Close();

                }
            }
            return View();

        }
        public bool CheckCoursesStu(Courses cour, int Studentid, int courseId, string day, TimeSpan startHour, TimeSpan endHour)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH; database = ProjectFinal;Integrated Security=SSPI");
            SqlCommand sda1 = new SqlCommand("select f.starthour,f.endhour from courses c,(select c.day, c.starthour, c.endhour from courses c, (select courseid from StudentinCourse where StudentId = '" + Studentid + "')d where d.CourseId=c.CourseId ) f where f.day=c.day and CourseId= '" + courseId + "'", con);
            sda1.Connection = con;
            con.Open();
            SqlDataReader sdr = sda1.ExecuteReader();

            List<Courses> objmodel = new List<Courses>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new Courses();
                    details.StartHour = TimeSpan.Parse(sdr["startHour"].ToString());
                    details.EndHour = TimeSpan.Parse(sdr["endHour"].ToString());
                    objmodel.Add(details);

                }
                cour.info = objmodel;
                con.Close();
            }
            else{
                cour.info = objmodel;
            }


            int i = 0;
            while (i < cour.info.Count())
            {

                bool a1 = (startHour >= cour.info[i].EndHour) || (endHour <= cour.info[i].StartHour);
                if (!a1)
                    return false;
                i++;
            }
            return true;
        }
 
        public bool CheckCoursesLec(Courses cour, int LecturerId, int courseId, string day, TimeSpan startHour, TimeSpan endHour)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O9SQCAH; database = ProjectFinal;Integrated Security=SSPI");
            SqlCommand sda1 = new SqlCommand("select DISTINCT f.starthour,f.endhour from courses c,(select day,starthour,endhour from courses where LectureId= '" + LecturerId + "')f where f.Day = '" + day + "'", con);
            sda1.Connection = con;
            con.Open();
            SqlDataReader sdr = sda1.ExecuteReader();

            List<Courses> objmodel = new List<Courses>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    var details = new Courses();
                    details.StartHour = TimeSpan.Parse(sdr["startHour"].ToString());
                    details.EndHour = TimeSpan.Parse(sdr["endHour"].ToString());
                    objmodel.Add(details);

                }
                cour.info = objmodel;
                con.Close();
            }
            else
            {
                cour.info = objmodel;
            }

            int i = 0;
            while (i < cour.info.Count())
            {

                bool a1 = (startHour >= cour.info[i].EndHour) || (endHour <= cour.info[i].StartHour);
                if (!a1)
                    return false;
                i++;
            }
            return true;
        }
    }

}