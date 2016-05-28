namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criteria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        CriteriaId = c.Int(nullable: false),
                        Preparedness = c.String(),
                        Interest = c.String(),
                        Accessibility = c.String(),
                        Examples = c.String(),
                        Enthusiasm = c.String(),
                        ClarityImportance = c.String(),
                        CommunicationDisciplines = c.String(),
                        ImproveMySkills = c.String(),
                        Ratio = c.String(),
                        Insistence = c.String(),
                        ObjectivityAssessment = c.String(),
                        Visit = c.String(),
                    })
                .PrimaryKey(t => t.CriteriaId)
                .ForeignKey("dbo.TeacherSubjects", t => t.CriteriaId)
                .Index(t => t.CriteriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Criteria", "CriteriaId", "dbo.TeacherSubjects");
            DropIndex("dbo.Criteria", new[] { "CriteriaId" });
            DropTable("dbo.Criteria");
        }
    }
}
