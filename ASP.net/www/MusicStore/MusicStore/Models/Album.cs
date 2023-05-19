using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Models
{
    public class Album
    {
        [Display( Name="Album")]
        public int AlbumID { get; set; }
        [Display(Name = "Genre")]
        public int GenreID { get; set; }
        [Display(Name = "Artist")]
        public int ArtistID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public Genre Genre { get; set; }
        public Artist Artist { get; set; }


        // Additionals:
        /*
        use: [DataType(DataType.Date)] for date fields.
        and: [Display(Name = "item it's Date")] for the display text of that field.

        use: [StringLength(60, MinimumLength = 3)] with String types for requirement checking.
        and: [Required] if the string field is required (Stings are nulls allowed by default).
        
        to set an attribute that is not part of the database fields (derrived):
        derrivedItem can then be used just like other attributes.
        public String derrivedItem {
            get { return "item1" + "item2"; }
        }

         */
    }
}
