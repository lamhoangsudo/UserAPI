using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("RoomType")]
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("RoomTypeID")]
        public int RoomTypeId { get; set; }
        [StringLength(50)]
        public string Type { get; set; } = null!;

        [InverseProperty("RoomType")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
