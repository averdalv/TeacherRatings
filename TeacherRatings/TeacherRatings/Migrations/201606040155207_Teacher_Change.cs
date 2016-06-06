namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teacher_Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Patronymic", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Teachers", "Information", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "LastName", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Teachers", "Information");
            DropColumn("dbo.Teachers", "Patronymic");
        }
    }
}
