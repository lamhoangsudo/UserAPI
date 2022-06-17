using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("Building")]
    public partial class Building
    {
        public Building()
        {
            Houses = new HashSet<House>();
        }

        [Key]
        [Column("BuildingID")]
        [StringLength(100)]
        public string BuildingId { get; set; } = null!;
        [Column("ApartmentID")]
        [StringLength(100)]
        public string ApartmentId { get; set; } = null!;
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(100)]
        public string Address { get; set; } = null!;
        public int NumberFloor { get; set; }
        public int NumberHouse { get; set; }
        public int Status { get; set; }

        [ForeignKey("ApartmentId")]
        [InverseProperty("Buildings")]
        public virtual Apartment Apartment { get; set; } = null!;
        [InverseProperty("Building")]
        public virtual ICollection<House> Houses { get; set; }
    }
}
