using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_MOVIE")]
    public partial class TblMovie
    {
        public TblMovie()
        {
            TblMovieActorMapping = new HashSet<TblMovieActorMapping>();
            TblMovieDirectorMapping = new HashSet<TblMovieDirectorMapping>();
            TblOrder = new HashSet<TblOrder>();
        }

        [Key]
        [Column("A_MOVIE_ID")]
        public int AMovieId { get; set; }
        [Required]
        [Column("A_TITLE")]
        [StringLength(200)]
        public string ATitle { get; set; }
        [Required]
        [Column("A_MOVIE_DESCRIPTION")]
        [StringLength(500)]
        public string AMovieDescription { get; set; }
        [Required]
        [Column("A_DURATION")]
        [StringLength(10)]
        public string ADuration { get; set; }
        [Required]
        [Column("A_PRICE")]
        [StringLength(20)]
        public string APrice { get; set; }
        [Required]
        [Column("A_PURCHASE_PRICE")]
        [StringLength(20)]
        public string APurchasePrice { get; set; }
        [Column("A_RATING")]
        public int ARating { get; set; }
        [Required]
        [Column("A_IMAGE_LINK")]
        [StringLength(200)]
        public string AImageLink { get; set; }
        [Required]
        [Column("A_TRAILER_LINK")]
        [StringLength(200)]
        public string ATrailerLink { get; set; }
        [Required]
        [Column("A_GENRE")]
        [StringLength(100)]
        public string AGenre { get; set; }
        [Required]
        [Column("A_WIDE_IMAGE")]
        [StringLength(400)]
        public string AWideImage { get; set; }

        [InverseProperty("AMovie")]
        public virtual ICollection<TblMovieActorMapping> TblMovieActorMapping { get; set; }
        [InverseProperty("AMovie")]
        public virtual ICollection<TblMovieDirectorMapping> TblMovieDirectorMapping { get; set; }
        [InverseProperty("AMovie")]
        public virtual ICollection<TblOrder> TblOrder { get; set; }
    }
}
