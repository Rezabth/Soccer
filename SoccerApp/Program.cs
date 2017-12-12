using SoccerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerApp
{
     class Program
    {
        
        static void Main(string[]arg)
        {
            using (var cx = new SocerContext())
            {

                foreach(var team in cx.Teams)
                {
                    Console.WriteLine(team.Name);
                    foreach(var teamPlayer in cx.TeamPlayers.Where(tp=>tp.TeamID == team.TeamID))
                    {
                        var player = cx.Players.Single(p => p.PlayerID == teamPlayer.PlayerID);
                        var fromDate = teamPlayer.StartsAt.ToString("yyyy-MM-dd");
                        var toDate = teamPlayer.EndsAt.ToString("yyyy-MM-dd");
                        Console.WriteLine($"{player.Name} is signed between {fromDate}{toDate}");
                    }
                }
            }
        }
    }
}
