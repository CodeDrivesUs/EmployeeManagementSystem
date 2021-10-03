namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastaname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplications", "LastName", c => c.String());
            DropColumn("dbo.JobApplications", "LarstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobApplications", "LarstName", c => c.String());
            DropColumn("dbo.JobApplications", "LastName");
        }
    }
}
