namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAdmissionRelations : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentGrades", name: "AddmitionId", newName: "AdmissionId");
            RenameIndex(table: "dbo.StudentGrades", name: "IX_AddmitionId", newName: "IX_AdmissionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.StudentGrades", name: "IX_AdmissionId", newName: "IX_AddmitionId");
            RenameColumn(table: "dbo.StudentGrades", name: "AdmissionId", newName: "AddmitionId");
        }
    }
}
