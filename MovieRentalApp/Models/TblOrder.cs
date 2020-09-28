using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_ORDER")]
    public partial class TblOrder
    {
        [Key]
        [Column("A_ORDER_ID")]
        public int AOrderId { get; set; }
        [Column("A_CUSTOMER_ID")]
        public int ACustomerId { get; set; }
        [Column("A_MOVIE_ID")]
        public int AMovieId { get; set; }
        [Column("A_RENTAL_OR_NOT")]
        public bool ARentalOrNot { get; set; }
        [Column("A_ORDERED_DATE", TypeName = "date")]
        public DateTime AOrderedDate { get; set; }
        [Column("A_DUE_DATE", TypeName = "date")]
        public DateTime? ADueDate { get; set; }

        [ForeignKey(nameof(ACustomerId))]
        [InverseProperty(nameof(TblUser.TblOrder))]
        public virtual TblUser ACustomer { get; set; }
        [ForeignKey(nameof(AMovieId))]
        [InverseProperty(nameof(TblMovie.TblOrder))]
        public virtual TblMovie AMovie { get; set; }
    }
}
