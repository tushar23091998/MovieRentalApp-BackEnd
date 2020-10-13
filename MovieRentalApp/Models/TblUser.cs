using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    [Table("TBL_USER")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblOrder = new HashSet<TblOrder>();
        }

        [Key]
        [Column("A_CUSTOMER_ID")]
        public int ACustomerId { get; set; }
        [Required]
        [Column("A_PASSWORD_HASH")]
        [MaxLength(200)]
        public byte[] APasswordHash { get; set; }
        [Required]
        [Column("A_PASSWORD_SALT")]
        [MaxLength(200)]
        public byte[] APasswordSalt { get; set; }
        //[Required]
        [Column("A_ADDRESS")]
        [StringLength(500)]
        public string AAddress { get; set; }
        [Column("A_DOB", TypeName = "date")]
        public DateTime ADob { get; set; }
        [Required]
        [Column("A_EMAIL")]
        [StringLength(200)]
        public string AEmail { get; set; }
        //[Required]
        [Column("A_PHONE")]
        [StringLength(10)]
        public string APhone { get; set; }
        [Required]
        [Column("A_NAME")]
        [StringLength(50)]
        public string Aname { get; set; }
        [Required]
        [Column("A_USERNAME")]
        [StringLength(50)]
        public string AUsername { get; set; }
        [Column("A_MOVIES_RENTED")]
        public int AMoviesRented { get; set; }
        [Column("A_ADMIN")]
        public bool AAdmin { get; set; }

        [InverseProperty("ACustomer")]
        public virtual ICollection<TblOrder> TblOrder { get; set; }
    }
}
