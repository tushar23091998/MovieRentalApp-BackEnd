using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_DIRECTOR")]
    public partial class TblDirector
    {
        public TblDirector()
        {
            TblMovieDirectorMapping = new HashSet<TblMovieDirectorMapping>();
        }

        [Key]
        [Column("A_DIRECTOR_ID")]
        public int ADirectorId { get; set; }
        [Required]
        [Column("A_DIRECTOR_NAME")]
        [StringLength(400)]
        public string ADirectorName { get; set; }

        [InverseProperty("ADirector")]
        public virtual ICollection<TblMovieDirectorMapping> TblMovieDirectorMapping { get; set; }
    }
}
