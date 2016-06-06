using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        
        
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountTeachers { get; set; }
    }
}