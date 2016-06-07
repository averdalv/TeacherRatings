using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.ViewModels
{
    public class TeacherPageViewModel
    {
        public int CountVoices { get; set; }
        public int[] voices{get;set;}
        public int CountLike { get; set; }

    }
}