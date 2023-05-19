using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MotoGP.Models.ViewModels
{
    public class ListTicketsViewModel
    {
        public List<Ticket> Tickets { get; set; }

        public SelectList Races { get; set; }

        public int raceID { get; set; }
    }
}
