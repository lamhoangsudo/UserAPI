using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("House")]
    public partial class House
    {
        public House()
        {
            RentPosts = new HashSet<RentPost>();
        }

        [Key]
        [Column("HouseID")]
        [StringLength(100)]
        public string HouseId { get; set; } = null!;
        [Column("BuildingID")]
        [StringLength(100)]
        public string BuildingId { get; set; } = null!;
        [Column("UserID")]
        [StringLength(100)]
        public string UserId { get; set; } = null!;
        [Column("HouseTypeID")]
        public int HouseTypeId { get; set; }
        public int Status { get; set; }
        public int FloorNumber { get; set; }
        public int HouseNumber { get; set; }

        [ForeignKey("BuildingId")]
        [InverseProperty("Houses")]
        public virtual Building Building { get; set; } = null!;
        [ForeignKey("HouseTypeId")]
        [InverseProperty("Houses")]
        public virtual HouseType HouseType { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Houses")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("House")]
        public virtual ICollection<RentPost> RentPosts { get; set; }
    }
}
