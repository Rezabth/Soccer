using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Models
{
    class TeamPlayer
    {
        public int TeamPlayerID { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }

        public int PlayerID { get; set; }
        public Player Player { get; set; }

        public  DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }


    }
}
