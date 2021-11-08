namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfleh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicantProfiles", "IdNumber", c => c.String());
            AddColumn("dbo.JobApplications", "TestResponse", c => c.Binary());
            AddColumn("dbo.JobVacancies", "TestUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobVacancies", "TestUrl");
            DropColumn("dbo.JobApplications", "TestResponse");
            DropColumn("dbo.ApplicantProfiles", "IdNumber");
        }
    }
}
