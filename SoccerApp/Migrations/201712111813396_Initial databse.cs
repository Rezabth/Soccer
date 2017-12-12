namespace SoccerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdatabse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.TeamPlayers",
                c => new
                    {
                        TeamPlayerID = c.Int(nullable: false, identity: true),
                        TeamID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        StartsAt = c.DateTime(nullable: false),
                        EndsAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TeamPlayerID)
                .ForeignKey("dbo.Players", t => t.PlayerID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamPlayers", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.TeamPlayers", "PlayerID", "dbo.Players");
            DropIndex("dbo.TeamPlayers", new[] { "PlayerID" });
            DropIndex("dbo.TeamPlayers", new[] { "TeamID" });
            DropTable("dbo.Teams");
            DropTable("dbo.TeamPlayers");
            DropTable("dbo.Players");
        }
    }
}
