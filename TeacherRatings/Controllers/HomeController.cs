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

            //Subject s1 = new Subject();
            //s1.Name = "Мат. аналіз";
            //Subject s2 = new Subject();
            //s2.Name = "ДО";
            //context.Subjects.Add(s1);
            //context.Subjects.Add(s2);
            //context.SaveChanges();

            //TeacherSubject ts = new TeacherSubject();
            //ts.SubjectId = 1;
            //ts.TeacherId = 2;

            //TeacherSubject ts2 = new TeacherSubject();
            //ts2.SubjectId = 2;
            //ts2.TeacherId = 2;

            //context.TeacherSubjects.Add(ts);
            //context.TeacherSubjects.Add(ts2);
            //context.SaveChanges();





            var t = context.Teachers;
            ViewBag.Teachers = t.ToList();  
            return View();
        }        
    }
}