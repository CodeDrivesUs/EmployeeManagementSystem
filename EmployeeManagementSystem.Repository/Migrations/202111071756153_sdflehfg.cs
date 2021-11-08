namespace EmployeeManagementSystem.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdflehfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interviews", "Comment", c => c.String());
            AddColumn("dbo.Interviews", "statusId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Interviews", "statusId");
            DropColumn("dbo.Interviews", "Comment");
        }
    }
}
