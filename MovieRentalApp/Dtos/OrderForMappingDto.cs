using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class OrderForMappingDto
    {
        public bool ARentalOrNot { get; set; }
        public DateTime AOrderedDate { get; set; }
        public DateTime? ADueDate { get; set; }
        public OrderToMovieDto AMovie { get; set; }
    }
}
