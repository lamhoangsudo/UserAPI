using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("Room")]
    public partial class Room
    {
        [Key]
        [Column("RoomID")]
        public int RoomId { get; set; }
        [Column("HouseTypeID")]
        public int HouseTypeId { get; set; }
        [Column("RoomTypeID")]
        public int RoomTypeId { get; set; }
        public int NumberRoom { get; set; }

        [ForeignKey("HouseTypeId")]
        [InverseProperty("Rooms")]
        public virtual HouseType HouseType { get; set; } = null!;
        [ForeignKey("RoomTypeId")]
        [InverseProperty("Rooms")]
        public virtual RoomType RoomType { get; set; } = null!;
    }
}
