namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobVacancy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobVacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        DevisionId = c.Int(nullable: false),
                        Tittle = c.String(),
                        Description = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        MaximumNumberOfApplications = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobVacancies");
        }
    }
}
