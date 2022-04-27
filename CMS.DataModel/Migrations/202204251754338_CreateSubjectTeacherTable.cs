namespace CMS.DataModel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateSubjectTeacherTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "AddmitionId", "dbo.Addmitions");
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropIndex("dbo.Classes", new[] { "AddmitionId" });
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TeacherId = c.Int(nullable: false),
                    SubjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);

            DropTable("dbo.Classes");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TeacherId = c.Int(nullable: false),
                    AddmitionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            DropForeignKey("dbo.SubjectTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeachers", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.SubjectTeachers", new[] { "SubjectId" });
            DropIndex("dbo.SubjectTeachers", new[] { "TeacherId" });
            DropTable("dbo.SubjectTeachers");
            CreateIndex("dbo.Classes", "AddmitionId");
            CreateIndex("dbo.Classes", "TeacherId");
            AddForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Classes", "AddmitionId", "dbo.Addmitions", "Id", cascadeDelete: true);
        }
    }
}
