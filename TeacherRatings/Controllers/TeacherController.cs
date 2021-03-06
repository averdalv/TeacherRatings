﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.Math;
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

       
        [HttpPost]
        
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

        public ActionResult ValueErrorPartial()
        {
            return PartialView();
        }
       
        [HttpGet]
        [Authorize]
        public ActionResult Value(int teacherId)
        {  

            var context = new DataContext();

            //bool alreadyValued = (from c in context.)

            ViewBag.Teacher = context.Teachers.Where(t => t.TeacherId == teacherId).First();
            var dep = context.Teachers.Where(p=>p.TeacherId==teacherId).Select(p => p.Department.Name).First();
            ViewBag.Department = dep;
            string UserId = (from c in context.Users
                             where c.Email == HttpContext.User.Identity.Name
                             select c.Id).First();

            List<int> idSubjectsAlreadyValuedForThisUser = new List<int>();
            idSubjectsAlreadyValuedForThisUser.AddRange((
                from c in context.TeacherUsers
                where (c.TeacherId == teacherId && c.UserId == UserId)
                select c.SubjectId
            ).ToList());

            ViewBag.Criterias = new List<string>();
            List<int> subjId = (from c in context.TeacherSubjects
                                where c.TeacherId == teacherId
                                select c.SubjectId).ToList();
            List<Subject> Sub = new List<Subject>();
            Sub.AddRange((
                from c in context.Subjects
                where (subjId.Contains(c.SubjectId) && !idSubjectsAlreadyValuedForThisUser.Contains(c.SubjectId))
                select c
            ).ToList());
            ViewBag.SubjectsValue = Sub;
            ViewBag.Subjects = (from c in context.Subjects
                                where subjId.Contains(c.SubjectId)
                                select c).ToList();
            if (!Sub.Any())
            {
                return PartialView("ValueErrorPartial");
            }
            else
            {
                
                foreach (var criteria in context.CriteriaStrings)
                {
                    ViewBag.Criterias.Add(criteria.CriteriaText);
                }

                CriteriaReturnViewModel crRet = new CriteriaReturnViewModel();
                crRet.TeacherId = teacherId.ToString();
                crRet.UserId = UserId;
                return View(crRet);
            }
            
        }

        [HttpPost]
        public ActionResult Value(CriteriaReturnViewModel crRet)
        {
            Statistics stat = new Statistics();
            stat.Update(crRet);
            var context = new DataContext();
            string UserId = (from c in context.Users
                             where c.Email == HttpContext.User.Identity.Name
                             select c.Id).First();
            Evaluation ev = new Evaluation();
            ev.Interest = int.Parse(crRet.Criterias[0]);
            ev.Accessibility = int.Parse(crRet.Criterias[1]);
            ev.ObjectivityAssessment = int.Parse(crRet.Criterias[2]);
            ev.Preparedness = int.Parse(crRet.Criterias[3]);
            ev.ClarityImportance = int.Parse(crRet.Criterias[4]);
            ev.Ratio = int.Parse(crRet.Criterias[5]);
            ev.Interest = int.Parse(crRet.Criterias[6]);
            ev.Visit = int.Parse(crRet.Criterias[7]);
            context.Evaluations.Add(ev);
            context.SaveChanges();
            TeacherUser tu = new TeacherUser();
            tu.User = (from c in context.Users
                       where c.Id == UserId
                       select c).First();
            tu.UserId = UserId;
            tu.Subject = (from c in context.Subjects
                          where c.SubjectId.ToString() == crRet.SubjectId
                          select c).First();
            tu.SubjectId = int.Parse(crRet.SubjectId);
            tu.Teacher = (from c in context.Teachers
                          where c.TeacherId.ToString() == crRet.TeacherId
                          select c).First();
            tu.TeacherId = int.Parse(crRet.TeacherId);
            tu.Evaluation = ev;
            context.TeacherUsers.Add(tu);
            context.SaveChanges();

            return RedirectToAction("TeacherPage", "Teacher", new { id = crRet.TeacherId });
        }
       
        public ActionResult TeacherPage(int id)
        {
             var context = new DataContext();
             var dep = context.Teachers.Where(p => p.TeacherId == id).Select(p => p.Department.Name).First();
             ViewBag.Department = dep;
             int[] voices = new int[] { 0, 0, 0, 0, 0 };
             int countVoices = 0;
             var teach = context.Teachers.Where(p => p.TeacherId == id).First();
             ViewBag.Teacher = teach;
             TeacherPageViewModel tpVM = new TeacherPageViewModel();
             var subteachQuery = context.TeacherSubjects.Where(t => t.TeacherId == teach.TeacherId).ToList();    
             var subteach = subteachQuery.Select(s => s.Subject).ToList();
             ViewBag.Subjects = subteach;
             var criteriaString = context.CriteriaStrings.ToList();
             ViewBag.Criterias = criteriaString;
            string[] criterias={};
            List<string> criteriaAll=new List<string>(); 
            if (subteachQuery.Count != 0)
            {
                criteriaAll = subteachQuery.Select(c => c.Criteria.Interest).ToList();
                
            }
            foreach(var crAll in criteriaAll){
                criterias = crAll.Split(new Char[] { ' ' });
             for (int i = 0; i < criterias.Length;i++ )
             {
                 switch(Int32.Parse(criterias[i]))
                 {
                     case 1: 
                         { 
                             voices[0]++;
                             break;
                         }
                     case 2:
                         {
                             voices[1]++;
                             break;
                         }
                     case 3:
                         {
                             voices[2]++;
                             break;
                         }
                     case 4:
                         {
                             voices[3]++;
                             break;
                         }
                     case 5:
                         {
                             voices[4]++;
                             break;
                         }
                 }
                 countVoices++;

             }
            }
             tpVM.CountVoices = countVoices;
             tpVM.voices = voices;
            
            return View(tpVM);
        }
        public JsonResult TeacherPageJson(int teacherid,string criterianame)
        {
            var context = new DataContext();
            TeacherPageViewModel tpVM = new TeacherPageViewModel();
            int[] voices = new int[] { 0, 0, 0, 0, 0 };
            int countVoices = 0;
            var teach = context.Teachers.Where(p => p.TeacherId == teacherid).First();
            var subteachQuery = context.TeacherSubjects.Where(t => t.TeacherId ==teacherid).ToList();
            string[] criterias = { };
            List<string> criteriaAll = new List<string>();
            if (subteachQuery.Count != 0)
            {
                 switch(criterianame)
                {
                    case "Interest":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Interest).ToList();
                            break;
                        }
                    case "Accessibility":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Accessibility).ToList();
                            break;
                        }
                    case "ObjectivityAssessment":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.ObjectivityAssessment).ToList();
                            break;
                        }
                             
                    case "Preparedness":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Preparedness).ToList();
                            break;
                        }
                         case "ClarityImportance":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.ClarityImportance).ToList();
                            break;
                        }
                    case "Ratio":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Ratio).ToList();
                            break;
                        }
                    case "Insistence":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Insistence).ToList();
                            break;
                        }
                             
                    case "Visit":
                        {
                            criteriaAll = subteachQuery.Select(c => c.Criteria.Visit).ToList();
                            break;
                        }

                }
                

            }
            foreach (var crAll in criteriaAll)
            {
                criterias = crAll.Split(new Char[] { ' ' });
                for (int i = 0; i < criterias.Length; i++)
                {
                    switch (Int32.Parse(criterias[i]))
                    {
                        case 1:
                            {
                                voices[0]++;
                                break;
                            }
                        case 2:
                            {
                                voices[1]++;
                                break;
                            }
                        case 3:
                            {
                                voices[2]++;
                                break;
                            }
                        case 4:
                            {
                                voices[3]++;
                                break;
                            }
                        case 5:
                            {
                                voices[4]++;
                                break;
                            }
                    }
                    countVoices++;

                }
            }
            tpVM.CountVoices = countVoices;
             tpVM.voices = voices;


             return Json(tpVM, JsonRequestBehavior.AllowGet);
        }
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
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult PartialSearch(string search)
        {
            var context = new DataContext();
            ViewBag.search = search;
            var teacher = context.Teachers.Where(t => t.Name.Contains(search) || t.LastName.Contains(search)||t.Patronymic.Contains(search)).ToList();
            return PartialView("PartialSearch",teacher);
        }

	}
}