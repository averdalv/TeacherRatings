namespace TeacherRatings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rebuild_Evaluation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evaluations", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Evaluations", new[] { "SubjectId" });
            RenameColumn(table: "dbo.Evaluations", name: "SubjectId", newName: "Subject_SubjectId");
            AddColumn("dbo.TeacherUsers", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Evaluations", "Subject_SubjectId", c => c.Int());
            CreateIndex("dbo.Evaluations", "Subject_SubjectId");
            CreateIndex("dbo.TeacherUsers", "SubjectId");
            AddForeignKey("dbo.TeacherUsers", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
            AddForeignKey("dbo.Evaluations", "Subject_SubjectId", "dbo.Subjects", "SubjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluations", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherUsers", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.TeacherUsers", new[] { "SubjectId" });
            DropIndex("dbo.Evaluations", new[] { "Subject_SubjectId" });
            AlterColumn("dbo.Evaluations", "Subject_SubjectId", c => c.Int(nullable: false));
            DropColumn("dbo.TeacherUsers", "SubjectId");
            RenameColumn(table: "dbo.Evaluations", name: "Subject_SubjectId", newName: "SubjectId");
            CreateIndex("dbo.Evaluations", "SubjectId");
            AddForeignKey("dbo.Evaluations", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}
