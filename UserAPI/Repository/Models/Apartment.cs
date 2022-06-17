using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("Apartment")]
    public partial class Apartment
    {
        public Apartment()
        {
            ApartmentInterests = new HashSet<ApartmentInterest>();
            Buildings = new HashSet<Building>();
        }

        [Key]
        [Column("ApartmentID")]
        [StringLength(100)]
        public string ApartmentId { get; set; } = null!;
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        public string Address { get; set; } = null!;
        public int Size { get; set; }
        public bool Internet { get; set; }

        [InverseProperty("Apartment")]
        public virtual ICollection<ApartmentInterest> ApartmentInterests { get; set; }
        [InverseProperty("Apartment")]
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
