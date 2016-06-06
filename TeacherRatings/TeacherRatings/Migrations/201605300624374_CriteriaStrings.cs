namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriteriaStrings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriteriaStrings",
                c => new
                    {
                        CriteriaStringsId = c.Int(nullable: false, identity: true),
                        CriteriaText = c.String(),
                        CriteriaName = c.String(),
                    })
                .PrimaryKey(t => t.CriteriaStringsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CriteriaStrings");
        }
    }
}
