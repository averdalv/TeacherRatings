namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abbreviation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Abbreviation", c => c.String(maxLength: 40));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 300));
            DropColumn("dbo.Departments", "Abbreviation");
        }
    }
}
