using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;

namespace TeacherRatings.Controllers
{
    public class ValueController : Controller
    {

        //Передаем конкретного препода и смотрим краткую инфу по ему и заполняем пердметы 
        [HttpGet]
        public ActionResult Value(int id)
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Value(string score)
        {
            //Получили оценочку. Потом много оценочек
            return RedirectToAction("Index", "Home");
        }
	}
}