using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherRatings.HelperClasses
{
    public class CriteriaReturn
    {
        public CriteriaReturn()
        {
        }
        public int teacherId{ get; set; }
        public int subjectId{ get; set; }
        public string Preparedness { get; set; }
        public string Interest{ get; set; }
        public string Accessibility{ get; set; }
        public string Examples{ get; set; }
        public string Enthusiasm{ get; set; }
        public string ClarityImportance{ get; set; }
        public string CommunicationDisciplines{ get; set; }
        public string ImproveMySkills{ get; set; }
        public string Ratio{ get; set; }
        public string Insistence{ get; set; }
        public string ObjectivityAssessment{ get; set; }
        public string Visit { get; set; }
    }
}