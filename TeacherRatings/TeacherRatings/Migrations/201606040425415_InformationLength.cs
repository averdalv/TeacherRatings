namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Information", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Information", c => c.String());
        }
    }
}
