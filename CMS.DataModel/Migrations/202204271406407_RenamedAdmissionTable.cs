namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAdmissionTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admissions", newName: "Admissions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Admissions", newName: "Admissions");
        }
    }
}
