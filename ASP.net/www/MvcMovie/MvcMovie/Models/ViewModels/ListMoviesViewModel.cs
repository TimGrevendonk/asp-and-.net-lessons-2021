using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models.ViewModels
{
    public class ListMoviesViewModel
    {
        // Properties in C# start with capital.
        public List<Movie> Movies { get; set; }
        public SelectList Ratings { get; set; }
        // No capital here because it corresponds to the name of the parameter in the view.
        public int ratingID { get; set; }
    }
}
