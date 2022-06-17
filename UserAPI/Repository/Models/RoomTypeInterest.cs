using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Keyless]
    [Table("RoomTypeInterest")]
    public partial class RoomTypeInterest
    {
        [Column("RoomTypeID")]
        public int RoomTypeId { get; set; }
        [Column("CustomerNeedID")]
        public int CustomerNeedId { get; set; }

        [ForeignKey("CustomerNeedId")]
        public virtual CustomerNeed CustomerNeed { get; set; } = null!;
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; } = null!;
    }
}
