namespace TeacherRatings.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    { 
        public DataContext()
            : base("name=DataContext")
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

    }

}