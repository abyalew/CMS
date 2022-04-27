namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRegistrationNumberFromStudentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "RegistrationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "RegistrationNumber", c => c.String());
        }
    }
}
