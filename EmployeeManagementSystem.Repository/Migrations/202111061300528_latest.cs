namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        profileId = c.Int(nullable: false),
                        UserId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        CV = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Resumes");
            DropTable("dbo.ApplicantProfiles");
        }
    }
}
