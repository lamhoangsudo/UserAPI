using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("HouseType")]
    public partial class HouseType
    {
        public HouseType()
        {
            Houses = new HashSet<House>();
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("HouseTypeID")]
        public int HouseTypeId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public bool? Balcony { get; set; }

        [InverseProperty("HouseType")]
        public virtual ICollection<House> Houses { get; set; }
        [InverseProperty("HouseType")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
