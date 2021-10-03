namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salarymodelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaries", "DivisionName", c => c.String());
            AddColumn("dbo.Salaries", "EmployeeName", c => c.String());
            AddColumn("dbo.Salaries", "PensionFund", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Salaries", "UIF", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Salaries", "TravelAllowance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salaries", "TravelAllowance");
            DropColumn("dbo.Salaries", "UIF");
            DropColumn("dbo.Salaries", "PensionFund");
            DropColumn("dbo.Salaries", "EmployeeName");
            DropColumn("dbo.Salaries", "DivisionName");
        }
    }
}
