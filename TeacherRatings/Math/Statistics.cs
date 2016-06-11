using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherRatings.Models;
using TeacherRatings.ViewModels;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace TeacherRatings.Math
{
    public class Statistics
    {
        public void Update(CriteriaReturnViewModel crRet)
        {
            var context = new DataContext();
            int teacherId = int.Parse(crRet.TeacherId);
            int subjectId = int.Parse(crRet.SubjectId);
            var criteria = (from row in context.TeacherSubjects
                            where (row.TeacherId == teacherId && row.SubjectId == subjectId)
                            select row.Criteria).First();
            criteria.Preparedness += " ";
            criteria.Preparedness += crRet.Criterias[0];
            criteria.Interest += " ";
            criteria.Interest += crRet.Criterias[1];
            criteria.Accessibility += " "; 
            criteria.Accessibility += crRet.Criterias[2];
            criteria.ClarityImportance += " "; 
            criteria.ClarityImportance += crRet.Criterias[3];
            criteria.Ratio += " ";
            criteria.Ratio += crRet.Criterias[4];
            criteria.Insistence +=" ";
            criteria.Insistence += crRet.Criterias[5];
            criteria.ObjectivityAssessment += " ";
            criteria.ObjectivityAssessment += crRet.Criterias[6];
            criteria.Visit += " ";
            criteria.Visit += crRet.Criterias[7];
            criteria.TeacherSubject = (from row in context.TeacherSubjects
                                       where (row.TeacherId == teacherId && row.SubjectId == subjectId)
                                       select row).First();
            context.SaveChanges();           

            //int c = criteria.Preparedness.ToList().Count(x => x == '1');
        }
    }
}