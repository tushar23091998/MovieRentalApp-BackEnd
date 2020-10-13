using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class MovieForListDto
    {
        [Required]
        public int? AMovieId { get; set; }
        [Required]
        public string? ATitle { get; set; }
        [Required]
        public string? AMovieDescription { get; set; }
        [Required]
        public string? ADuration { get; set; }
        [Required]
        public string? APrice { get; set; }
        [Required]
        public string? APurchasePrice { get; set; }
        [Required]
        public int? ARating { get; set; }
        [Required]
        public string? AImageLink { get; set; }
        [Required]
        public string? ATrailerLink { get; set; }
        [Required]
        public string? AGenre { get; set; }
        [Required]
        public string? AWideImage { get; set; }
    }
}
