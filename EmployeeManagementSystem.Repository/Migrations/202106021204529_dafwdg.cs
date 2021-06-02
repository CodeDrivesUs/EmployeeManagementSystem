namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dafwdg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        leaveType = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        appliedon = c.DateTime(nullable: false),
                        reason = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        statusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Leaves");
        }
    }
}
