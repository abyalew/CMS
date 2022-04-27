namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeColumnToStudentGradeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentGrades", "Grade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentGrades", "Grade");
        }
    }
}
