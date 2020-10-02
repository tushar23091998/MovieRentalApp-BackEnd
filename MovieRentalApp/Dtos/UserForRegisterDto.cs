using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(50)]
        public string AUsername { get; set; }

        [Required]
        [StringLength(12,MinimumLength=6,ErrorMessage ="You must specify password between 6 and 12 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string AEmail { get; set; }

        [Required]
        [StringLength(50)]
        public string Aname { get; set; }

        [Required]
        public DateTime ADob { get; set; }
    }
}
