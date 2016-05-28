using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.HelperClasses;

namespace TeacherRatings.Math
{
    public class Statistics
    {
        public void Update(CriteriaReturn crRet)
        {
            var context = new DataContext();
            var criteria = (from row in context.TeacherSubjects
                            where (row.TeacherId == crRet.teacherId && row.SubjectId == crRet.subjectId)
                            select row.Criteria).First();
            criteria.Preparedness += crRet.Preparedness;
            criteria.Interest += crRet.Interest;
            criteria.Accessibility += crRet.Accessibility;
            criteria.Examples += crRet.Examples;
            criteria.Enthusiasm += crRet.Enthusiasm;
            criteria.ClarityImportance += crRet.ClarityImportance;
            criteria.CommunicationDisciplines += crRet.CommunicationDisciplines;
            criteria.ImproveMySkills += crRet.ImproveMySkills;
            criteria.Ratio += crRet.Ratio;
            criteria.Insistence += crRet.Insistence;
            criteria.ObjectivityAssessment += crRet.ObjectivityAssessment;
            criteria.Visit += crRet.Visit;
            context.SaveChanges();

            //int c = criteria.Preparedness.ToList().Count(x => x == '1');
        }
    }
}