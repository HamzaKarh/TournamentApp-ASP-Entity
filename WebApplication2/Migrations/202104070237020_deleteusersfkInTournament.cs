namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteusersfkInTournament : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tournament", "user_id");
            RenameColumn(table: "dbo.tournament", name: "user_id1", newName: "user_id");
            RenameIndex(table: "dbo.tournament", name: "IX_user_id1", newName: "IX_user_id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tournament", name: "IX_user_id", newName: "IX_user_id1");
            RenameColumn(table: "dbo.tournament", name: "user_id", newName: "user_id1");
            AddColumn("dbo.tournament", "user_id", c => c.Int());
        }
    }
}
