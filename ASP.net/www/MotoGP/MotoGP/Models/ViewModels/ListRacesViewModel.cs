using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MotoGP.Models.ViewModels
{
    public class ListRacesViewModel
    {
        // Properties in C# start with capital.
        public SelectList Races { get; set; }

        public Race Race { get; set; }
        // No capital here because it corresponds to the name of the parameter in the view.
        public int raceID { get; set; }
    }
}
