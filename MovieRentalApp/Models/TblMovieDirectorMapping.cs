using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_MOVIE_DIRECTOR_MAPPING")]
    public partial class TblMovieDirectorMapping
    {
        [Key]
        [Column("A_MOVIE_ID")]
        public int AMovieId { get; set; }
        [Key]
        [Column("A_DIRECTOR_ID")]
        public int ADirectorId { get; set; }

        [ForeignKey(nameof(ADirectorId))]
        [InverseProperty(nameof(TblDirector.TblMovieDirectorMapping))]
        public virtual TblDirector ADirector { get; set; }
        [ForeignKey(nameof(AMovieId))]
        [InverseProperty(nameof(TblMovie.TblMovieDirectorMapping))]
        public virtual TblMovie AMovie { get; set; }
    }
}
