using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class UserForListDto
    {
        public int? ACustomerId { get; set; }
        public string AAddress { get; set; }
        public int? Age { get; set; }
        [Required]
        public string AEmail { get; set; }
        public string APhone { get; set; }
        [Required]
        public string Aname { get; set; }
        [Required]
        public string AUsername { get; set; }
        public int? AMoviesRented { get; set; }
        public bool? AAdmin { get; set; }
    }
}
