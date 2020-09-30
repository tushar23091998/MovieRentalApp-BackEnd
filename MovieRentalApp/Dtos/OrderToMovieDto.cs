using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class OrderToMovieDto
    {
        public int AMovieId { get; set; }
        public string ATitle { get; set; }
        public string AMovieDescription { get; set; }
        public string ADuration { get; set; }
        public string APrice { get; set; }
        public string APurchasePrice { get; set; }
        public int ARating { get; set; }
        public string AImageLink { get; set; }
        public string ATrailerLink { get; set; }
        public string AGenre { get; set; }
        public string AWideImage { get; set; }
    }
}
