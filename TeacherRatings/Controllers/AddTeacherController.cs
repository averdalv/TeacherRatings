using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;

namespace TeacherRatings.Controllers
{
    public class AddTeacherController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.t = "Hallo From AddCont!";
            var context = new DataContext();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var dep in context.Departments)
            {
                list.Add(new SelectListItem() { Text = dep.Name.ToString(), Value = dep.DepartmentId.ToString() });
            }
            ViewBag.list = list;
            return View();

        }

        //Вызывается когда была нажата кнопка "добавить" в форме добавления препод.
        [HttpPost]
        //[NonAction]
        public string Add(Teacher teacher, int Department_DepartmentId)
        {
            var context = new DataContext();

            teacher.Department = (from c in context.Departments
                                  where c.DepartmentId == Department_DepartmentId
                                  select c).First();

            context.Teachers.Add(teacher);
            context.SaveChanges();

            return "DYAKUYU";
        }

        //public ActionResult Thanks()
        //{
        //    return View();
        //}
	}
}