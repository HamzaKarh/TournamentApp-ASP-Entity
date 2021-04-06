namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.userRole",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        role_name = c.String(),
                    })
                .PrimaryKey(t => t.role_id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        user_id = c.Long(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 255),
                        last_name = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        role_id = c.Int(),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("dbo.userRole", t => t.role_id)
                .Index(t => t.role_id);
            
            AddColumn("dbo.tournament", "user_id", c => c.Long());
            CreateIndex("dbo.tournament", "user_id");
            AddForeignKey("dbo.tournament", "user_id", "dbo.user", "user_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tournament", "user_id", "dbo.user");
            DropForeignKey("dbo.user", "role_id", "dbo.userRole");
            DropIndex("dbo.user", new[] { "role_id" });
            DropIndex("dbo.tournament", new[] { "user_id" });
            DropColumn("dbo.tournament", "user_id");
            DropTable("dbo.user");
            DropTable("dbo.userRole");
        }
    }
}
