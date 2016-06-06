using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class TeachersViewModel
    {
        public List<TeacherPagination> Teachers { get; set; }
        public Pagination PageInfo { get; set; }
        public int DepartentId { get; set; }
    }
}