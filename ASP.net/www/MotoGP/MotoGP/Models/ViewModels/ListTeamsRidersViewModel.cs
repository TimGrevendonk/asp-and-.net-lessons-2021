using System.Collections.Generic;

namespace MotoGP.Models.ViewModels
{
    public class ListTeamsRidersViewModel
    {
        public List<Team> Teams { get; set; }
        public List<Rider> Riders { get; set; }
        public int teamID { get; set; } 
    }
}
