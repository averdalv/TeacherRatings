using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
namespace TeacherRatings.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            var context = new DataContext();
            var teach = context.Teachers;
            ViewBag.Teachers = teach;

            //TeacherSubject ts = new TeacherSubject();

            //ts.Teacher = context.Teachers.First(); ;
            //ts.Subject = context.Subjects.First(); ;         

            //Criteria c = new Criteria();
            //c.Accessibility = c.ClarityImportance = c.CommunicationDisciplines = c.Enthusiasm =
            //    c.Examples = c.ImproveMySkills = c.Insistence = c.Interest = c.ObjectivityAssessment = c.Preparedness =
            //    c.Ratio = c.Visit = "";
            //c.TeacherSubject = ts;

            //context.TeacherSubjects.Add(ts);
            //context.Criterias.Add(c);
            //context.SaveChanges();
            return View();
        }        
    }
}