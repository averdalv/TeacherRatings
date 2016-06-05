using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class TeacherPagination
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic {get;set;}   
        public string Information { get; set; } //информация про преподавателя
        public string Image { get; set; }
        public string Link { get; set; } //ссылка на страницу преподавателя
    }
}