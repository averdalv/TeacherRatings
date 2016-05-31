using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.Math;
using TeacherRatings.HelperClasses;

namespace TeacherRatings.Controllers
{
    public class TeacherController : Controller
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

        //Передаем конкретного препода и смотрим краткую инфу по ему и заполняем пердметы 
        [HttpGet]
        public ActionResult Value(int teacherId, int subjectId)
        {  

          var context = new DataContext();

            //TeacherSubject tc = new TeacherSubject();
            //tc.TeacherId = 1;
            //tc.SubjectId = 1;

            //Criteria cr = new Criteria();
            //cr.Accessibility = "1";
            //cr.ClarityImportance = "4";
            //cr.CommunicationDisciplines = "1";
            //cr.ImproveMySkills = "5";
            //cr.Interest = "1";
            //cr.ObjectivityAssessment = "5";
            //cr.Preparedness = "1";
            //cr.Ratio = "4";
            //cr.Insistence = "4";
            //cr.Visit = "5";
            //cr.Enthusiasm = "1";
            //cr.Examples = "5";
           // cr.TeacherSubject = tc;

           // context.TeacherSubjects.Add(tc);
           // context.Criterias.Add(cr);
           // context.SaveChanges();



           // context.Criterias.Add(cr);
          //  context.SaveChanges();
            //Оценим предмет с ад = 1
            //var criteria = (from el in context.TeacherSubjects
            //                where (el.TeacherId == teacherId && el.SubjectId == 1)
            //                select el.Criteria);


            //Ne Ok. Потом переделаю. Для дебага пойдет / В базе будет потом
            //List<string> list = new List<string>();
            ViewBag.Criterias = new List<string>();
            foreach(var criteria in context.CriteriaStrings)
            {
                ViewBag.Criterias.Add(criteria.CriteriaText);
            }

            CriteriaReturn crRet = new CriteriaReturn();
            crRet.teacherId = teacherId;
            crRet.subjectId = subjectId;
            return View(crRet);
        }

        [HttpPost]
        public ActionResult Value(CriteriaReturn crRet)
        {
            Statistics stat = new Statistics();
            stat.Update(crRet);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult TeacherPage()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
	}
}