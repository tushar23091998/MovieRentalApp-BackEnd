using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class UserForListDto
    {
        public int ACustomerId { get; set; }
        public string AAddress { get; set; }
        public int Age { get; set; }
        public string AEmail { get; set; }
        public string APhone { get; set; }
        public string Aname { get; set; }
        public string AUsername { get; set; }
        public int AMoviesRented { get; set; }
        public bool AAdmin { get; set; }
    }
}
