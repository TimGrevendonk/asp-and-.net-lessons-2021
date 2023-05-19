using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MusicStore.Models.ViewModels
{
    // ViewModel gets used in "AlbumsController".
    public class ListAlbumsViewModel
    {
        public SelectList Artists { get; set; }
        public SelectList Genres { get; set; }
        public List<Album> Albums { get; set; }
        public string Title { get; set; }
        public int artistID { get; set; }
        public int genreID { get; set; }
    }
}
