namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Teacher_Evaluations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        EvaluationId = c.Int(nullable: false, identity: true),
                        Preparedness = c.Int(nullable: false),
                        Interest = c.Int(nullable: false),
                        Accessibility = c.Int(nullable: false),
                        ClarityImportance = c.Int(nullable: false),
                        Ratio = c.Int(nullable: false),
                        Insistence = c.Int(nullable: false),
                        ObjectivityAssessment = c.Int(nullable: false),
                        Visit = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluationId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.TeacherUsers",
                c => new
                    {
                        TeacherUserId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        EvaluationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherUserId)
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.TeacherId)
                .Index(t => t.UserId)
                .Index(t => t.EvaluationId);
            
            AddColumn("dbo.TeacherSubjects", "CriteriaId", c => c.Int(nullable: false));
            DropColumn("dbo.Criteria", "Examples");
            DropColumn("dbo.Criteria", "Enthusiasm");
            DropColumn("dbo.Criteria", "CommunicationDisciplines");
            DropColumn("dbo.Criteria", "ImproveMySkills");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Criteria", "ImproveMySkills", c => c.String());
            AddColumn("dbo.Criteria", "CommunicationDisciplines", c => c.String());
            AddColumn("dbo.Criteria", "Enthusiasm", c => c.String());
            AddColumn("dbo.Criteria", "Examples", c => c.String());
            DropForeignKey("dbo.TeacherUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeacherUsers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherUsers", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.Evaluations", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.TeacherUsers", new[] { "EvaluationId" });
            DropIndex("dbo.TeacherUsers", new[] { "UserId" });
            DropIndex("dbo.TeacherUsers", new[] { "TeacherId" });
            DropIndex("dbo.Evaluations", new[] { "SubjectId" });
            DropColumn("dbo.TeacherSubjects", "CriteriaId");
            DropTable("dbo.TeacherUsers");
            DropTable("dbo.Evaluations");
        }
    }
}
