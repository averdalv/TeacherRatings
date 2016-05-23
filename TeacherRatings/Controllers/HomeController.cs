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
            return View();
        }

        public ActionResult Teachers()
        {
            return View();
        }
    }
}