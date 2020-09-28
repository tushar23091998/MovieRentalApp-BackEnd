using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_MOVIE_ACTOR_MAPPING")]
    public partial class TblMovieActorMapping
    {
        [Key]
        [Column("A_MOVIE_ID")]
        public int AMovieId { get; set; }
        [Key]
        [Column("A_ACTOR_ID")]
        public int AActorId { get; set; }

        [ForeignKey(nameof(AActorId))]
        [InverseProperty(nameof(TblActor.TblMovieActorMapping))]
        public virtual TblActor AActor { get; set; }
        [ForeignKey(nameof(AMovieId))]
        [InverseProperty(nameof(TblMovie.TblMovieActorMapping))]
        public virtual TblMovie AMovie { get; set; }
    }
}
