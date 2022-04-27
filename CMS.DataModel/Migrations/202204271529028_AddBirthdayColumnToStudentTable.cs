namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayColumnToStudentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Birthday");
        }
    }
}
