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
using Project.ViewModel;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult StudentCourse()
        {
            var id = (int)Session["ID"];

            Student_Schedule_Course_ExamsDal SSCED = new Student_Schedule_Course_ExamsDal();
            List<Student_Schedule_Course_Exam> schedule = (from x in SSCED.students_schedule_course_exams where x.StudentID.Equals(id) select x).ToList<Student_Schedule_Course_Exam>();
            ViewBag.schedules = schedule;
            return View("StudentCourse");

        }
        public ActionResult StudentSchedule()
        {
            var id = (int)Session["ID"];

            Student_Schedule_Course_ExamsDal SSCED = new Student_Schedule_Course_ExamsDal();
            List<Student_Schedule_Course_Exam> schedule = (from x in SSCED.students_schedule_course_exams where x.StudentID.Equals(id) select x).ToList<Student_Schedule_Course_Exam>();
            ViewBag.schedules = schedule;
            return View("StudentSchedule");
        }
        public ActionResult StudentExams()
        {
            var id = (int)Session["ID"];

            Student_Schedule_Course_ExamsDal SSCED = new Student_Schedule_Course_ExamsDal();
            List<Student_Schedule_Course_Exam> schedule = (from x in SSCED.students_schedule_course_exams where x.StudentID.Equals(id) select x).ToList<Student_Schedule_Course_Exam>();
            ViewBag.schedules = schedule;
            return View("StudentExams");
        }
    }

}