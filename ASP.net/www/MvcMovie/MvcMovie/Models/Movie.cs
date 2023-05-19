using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        // Required is making it not nullable in the database.
        [Required]
        // Display name for using with "DisplayNameFor(...)" (not hardcoded).
        [Display(Name = "Film Title")]
        public string Title { get; set; }

        // Set the datetime to a day-month-year format only.
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,
          DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required] public string Genre { get; set; }
        public int? Price { get; set; }
        public int RatingID { get; set; }

        public Rating Rating { get; set; }
    }
}
