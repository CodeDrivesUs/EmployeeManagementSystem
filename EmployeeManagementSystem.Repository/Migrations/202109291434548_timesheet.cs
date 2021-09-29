namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timesheet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeSheets");
        }
    }
}
