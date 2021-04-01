namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAllDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.game",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        date = c.DateTime(precision: 6, storeType: "datetime2"),
                        bteam_id = c.Long(),
                        rteam_id = c.Long(),
                        tournament_id = c.Long(),
                        winner_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.team", t => t.rteam_id)
                .ForeignKey("dbo.team", t => t.winner_id)
                .ForeignKey("dbo.team", t => t.bteam_id)
                .ForeignKey("dbo.tournament", t => t.tournament_id)
                .Index(t => t.bteam_id)
                .Index(t => t.rteam_id)
                .Index(t => t.tournament_id)
                .Index(t => t.winner_id);
            
            CreateTable(
                "dbo.team",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                        nb_members = c.Int(),
                        captain_id = c.Long(),
                        tournament_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.player", t => t.captain_id)
                .ForeignKey("dbo.tournament", t => t.tournament_id)
                .Index(t => t.captain_id)
                .Index(t => t.tournament_id);
            
            CreateTable(
                "dbo.player",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                        team_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.team", t => t.team_id)
                .Index(t => t.team_id);
            
            CreateTable(
                "dbo.tournament",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255, unicode: false),
                        nb_participants = c.Int(),
                        description = c.String(maxLength: 255, unicode: false),
                        game = c.String(nullable: false, maxLength: 255, unicode: false),
                        start_date = c.DateTime(precision: 6, storeType: "datetime2"),
                        started = c.Binary(maxLength: 1, fixedLength: true),
                        team_size = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.team", "tournament_id", "dbo.tournament");
            DropForeignKey("dbo.game", "tournament_id", "dbo.tournament");
            DropForeignKey("dbo.player", "team_id", "dbo.team");
            DropForeignKey("dbo.team", "captain_id", "dbo.player");
            DropForeignKey("dbo.game", "bteam_id", "dbo.team");
            DropForeignKey("dbo.game", "winner_id", "dbo.team");
            DropForeignKey("dbo.game", "rteam_id", "dbo.team");
            DropIndex("dbo.player", new[] { "team_id" });
            DropIndex("dbo.team", new[] { "tournament_id" });
            DropIndex("dbo.team", new[] { "captain_id" });
            DropIndex("dbo.game", new[] { "winner_id" });
            DropIndex("dbo.game", new[] { "tournament_id" });
            DropIndex("dbo.game", new[] { "rteam_id" });
            DropIndex("dbo.game", new[] { "bteam_id" });
            DropTable("dbo.tournament");
            DropTable("dbo.player");
            DropTable("dbo.team");
            DropTable("dbo.game");
        }
    }
}
