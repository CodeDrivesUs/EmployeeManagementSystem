namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        ContratId = c.Int(nullable: false),
                        UserSignedAt = c.String(),
                        Contract = c.Binary(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contracts");
            DropTable("dbo.ApplicationContracts");
        }
    }
}
