using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.Math;
using TeacherRatings.HelperClasses;
using TeacherRatings.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

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
        public ActionResult Value(int teacherId)
        {  

            var context = new DataContext();

            //ApplicationUserManager appMan = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //ApplicationUser appUser = appMan.FindAsync();
            string UserId = (from c in context.Users
                             where c.Email == HttpContext.User.Identity.Name
                             select c.Id).First();

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
            List<int> subjId = (from c in context.TeacherSubjects
                                where c.TeacherId == teacherId
                                select c.SubjectId).ToList();
            List<Subject> Sub = new List<Subject>();
            Sub.AddRange((from c in context.Subjects
                          where subjId.Contains(c.SubjectId)
                          select c).ToList());
            ViewBag.Subjects = Sub;

            foreach(var criteria in context.CriteriaStrings)
            {
                ViewBag.Criterias.Add(criteria.CriteriaText);
            }

            CriteriaReturn crRet = new CriteriaReturn();
            crRet.TeacherId= teacherId.ToString();
            crRet.UserId = UserId;
            return View(crRet);
        }

        [HttpPost]
        public ActionResult Value(CriteriaReturn crRet)
        {
            Statistics stat = new Statistics();
            stat.Update(crRet);

            return RedirectToAction("Index", "Home");
        }
       
        public ActionResult TeacherPage(int id)
        {
            return View();
        }
       /* public ActionResult Teachers()
        {
            var context = new DataContext();
            var departments = context.Departments.ToList();
            List<DepartmentViewModel> departmentVM = new List<DepartmentViewModel>();
            foreach (var d in departments)
            {
                DepartmentViewModel dvm = new DepartmentViewModel();
                dvm.Name = d.Name;
                dvm.DepartmentId = d.DepartmentId;
                dvm.Abbreviation = d.Abbreviation;

                dvm.CountTeachers = d.Teachers.Count;
                departmentVM.Add(dvm);
            }
            ViewBag.Departments = departmentVM;
            return View();
        }*/

        //Получаем преподавателей по кафедре и странице
        public ActionResult Teachers(int? id,int? page)
        {   var context=new DataContext();
            int pageCount;
            int pageSize=4;
            var departments=context.Departments.ToList();
            List<DepartmentViewModel> departmentVM=new List<DepartmentViewModel>();
            foreach(var d in departments)
            {
                DepartmentViewModel dvm = new DepartmentViewModel();
                dvm.Name = d.Name;
                dvm.DepartmentId = d.DepartmentId;
                dvm.Abbreviation = d.Abbreviation;

                dvm.CountTeachers = d.Teachers.Count;
                departmentVM.Add(dvm);
            }
            ViewBag.Departments = departmentVM;
            bool view=false;
            if(id==null&&page==null)
            {
                id = departments.First().DepartmentId;
                page = 1;
                view=true;//если пользователь не кликал по вкалке или странице, а просто перешел по ссылке
            }
            else if(page==null)page=1;
            
                var count=context.Teachers.Where(d=>d.Department.DepartmentId==id).Count();
                pageCount=count/pageSize;
                if(count%pageSize!=0)pageCount++;
                Pagination Pag=new Pagination(){PageCount=pageCount,CurrentPage=(int)page,PageSize=9,ItemsCount=count};
                List<TeacherPagination> TeachPag=new List<TeacherPagination>();
                var teachers = context.Teachers.Where(d => d.Department.DepartmentId == id).ToList().Skip((int)(page - 1) * pageSize).Take(pageSize);
                foreach(var teacher in teachers)
                {
                    TeacherPagination teacherPagination =new TeacherPagination();
                    teacherPagination.Name=teacher.Name;
                    teacherPagination.LastName=teacher.LastName;
                    teacherPagination.Patronymic=teacher.Patronymic;
                    teacherPagination.Information = teacher.Information.Substring(0, (teacher.Information.Length < 200 ? teacher.Information.Length : 200)) + "...";
                    teacherPagination.Image=teacher.Image;
                    teacherPagination.Link=@"TeacherPage?"+"id="+teacher.TeacherId;
                    TeachPag.Add(teacherPagination);
                }
                TeachersViewModel model=new TeachersViewModel(){Teachers=TeachPag,PageInfo=Pag,DepartentId=teachers.First().Department.DepartmentId};
                if (view)
                    return View(model);
                 return PartialView("TeachersPartial", model);
           

        }
	}
}