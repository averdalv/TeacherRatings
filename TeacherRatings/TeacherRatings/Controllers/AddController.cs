using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;

namespace TeacherRatings.Controllers
{
    public class AddController : Controller
    {
        //
        // GET: /Add/
        // Будет вызвана при добавлении нового преподавателя
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.t = "Hallo From AddCont!";
            return View();

        }

        //Вызывается когда была нажата кнопка "добавить" в форме добавления препод.
        [HttpPost]
        public ActionResult Add(Teacher teacher)
        {
            var context = new DataContext();
            context.Teachers.Add(teacher);
            context.SaveChanges();
            int c = ViewBag.dep;
            return View("Thanks", teacher);
        }

        public ActionResult Thanks()
        {
            return View();
        }
	}
}