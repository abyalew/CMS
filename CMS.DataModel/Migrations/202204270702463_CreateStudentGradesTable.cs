namespace CMS.DataModel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateStudentGradesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentGrades",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AddmitionId = c.Int(nullable: false),
                    SubjectId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addmitions", t => t.AddmitionId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.AddmitionId)
                .Index(t => t.SubjectId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentGrades", "AddmitionId", "dbo.Addmitions");
            DropIndex("dbo.StudentGrades", new[] { "SubjectId" });
            DropIndex("dbo.StudentGrades", new[] { "AddmitionId" });
            DropTable("dbo.StudentGrades");
        }
    }
}
