namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsersModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.user", "role_id", "dbo.userRoles");
            DropIndex("dbo.user", new[] { "role_id" });
            DropTable("dbo.userRoles");
            DropTable("dbo.user");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.userRoles",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        role_name = c.String(),
                    })
                .PrimaryKey(t => t.role_id);
            
            CreateIndex("dbo.user", "role_id");
            AddForeignKey("dbo.user", "role_id", "dbo.userRoles", "role_id", cascadeDelete: true);
        }
    }
}
