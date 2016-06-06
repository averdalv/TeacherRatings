namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Image");
        }
    }
}
