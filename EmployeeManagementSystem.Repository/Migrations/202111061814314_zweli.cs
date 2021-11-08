namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zweli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "FileName");
        }
    }
}
