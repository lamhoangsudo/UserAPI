using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("ApartmentInterest")]
    public partial class ApartmentInterest
    {
        [Column("ApartmentID")]
        [StringLength(100)]
        public string ApartmentId { get; set; } = null!;
        [Column("PointOfInterestID")]
        public int PointOfInterestId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("ApartmentId")]
        [InverseProperty("ApartmentInterests")]
        public virtual Apartment Apartment { get; set; } = null!;
        [ForeignKey("PointOfInterestId")]
        [InverseProperty("ApartmentInterests")]
        public virtual PointOfInterest PointOfInterest { get; set; } = null!;
    }
}
