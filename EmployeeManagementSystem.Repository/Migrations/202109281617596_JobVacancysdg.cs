namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobVacancysdg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobVacancies", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobVacancies", "Type");
        }
    }
}
