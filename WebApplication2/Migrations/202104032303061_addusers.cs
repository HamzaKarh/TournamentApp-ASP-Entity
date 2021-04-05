namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.userRoles", newName: "userRole");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.userRole", newName: "userRoles");
        }
    }
}
