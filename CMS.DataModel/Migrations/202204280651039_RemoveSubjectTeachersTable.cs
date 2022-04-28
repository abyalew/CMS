namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubjectTeachersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectTeachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.SubjectTeachers", new[] { "TeacherId" });
            DropIndex("dbo.SubjectTeachers", new[] { "SubjectId" });
            AddColumn("dbo.Subjects", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "TeacherId");
            AddForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            DropTable("dbo.SubjectTeachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Subjects", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Subjects", new[] { "TeacherId" });
            DropColumn("dbo.Subjects", "TeacherId");
            CreateIndex("dbo.SubjectTeachers", "SubjectId");
            CreateIndex("dbo.SubjectTeachers", "TeacherId");
            AddForeignKey("dbo.SubjectTeachers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubjectTeachers", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
