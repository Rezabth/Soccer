namespace SoccerApp.Migrations
{
    using SoccerApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoccerApp.Models.SocerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoccerApp.Models.SocerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var teamOne = new Team { Name = "Team One" };
            context.Teams.Add(teamOne);

            var playerOne = new Player { Name = "Player One" };
            context.Players.Add(playerOne);

            var teamPlayerOne = new TeamPlayer { Team = teamOne, Player = playerOne, StartsAt = new DateTime(2007, 1, 1), EndsAt = new DateTime(2018, 1, 1) };
            context.TeamPlayers.Add(teamPlayerOne);

            context.SaveChanges();

        }
    }
}
