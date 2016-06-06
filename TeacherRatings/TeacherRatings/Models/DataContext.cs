namespace TeacherRatings.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : IdentityDbContext<ApplicationUser>
    { 
        public DataContext()
            : base("DataContext")
        {
        }
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<CriteriaStrings> CriteriaStrings { get; set; }
    }

}