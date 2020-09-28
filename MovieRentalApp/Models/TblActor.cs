using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_ACTOR")]
    public partial class TblActor
    {
        public TblActor()
        {
            TblMovieActorMapping = new HashSet<TblMovieActorMapping>();
        }

        [Key]
        [Column("A_ACTOR_ID")]
        public int AActorId { get; set; }
        [Required]
        [Column("A_ACTOR_NAME")]
        [StringLength(400)]
        public string AActorName { get; set; }

        [InverseProperty("AActor")]
        public virtual ICollection<TblMovieActorMapping> TblMovieActorMapping { get; set; }
    }
}
