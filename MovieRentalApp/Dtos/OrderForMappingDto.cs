using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class OrderForMappingDto
    {
        [Required]
        public int? ACustomerId { get; set; }
        [Required]
        public int? AMovieId { get; set; }
        [Required]
        public bool? ARentalOrNot { get; set; }
        [Required]
        public DateTime? AOrderedDate { get; set; }
        public DateTime? ADueDate { get; set; }
        public OrderToMovieDto AMovie { get; set; }
    }
}
