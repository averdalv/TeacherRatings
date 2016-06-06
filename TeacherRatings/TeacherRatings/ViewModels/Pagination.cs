using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class Pagination
    {
        public int PageCount { get; set; } //кол-во страниц
        public int CurrentPage { get; set; } //текущая страница
        public int PageSize { get; set; } //кол-во преподавателей на странице
        public int ItemsCount { get; set; }//Всего преподавателей (по кафедрам)
    }
}