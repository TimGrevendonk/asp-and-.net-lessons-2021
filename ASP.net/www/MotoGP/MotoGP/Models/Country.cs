using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }
        public string Name { get; set; }

        // Foreign key referes to Rider table.
        public ICollection<Rider> Riders { get; set; }

        // Foreign key referes to Ticket table.
        public ICollection<Ticket> Tickets { get; set; }
    }
}
