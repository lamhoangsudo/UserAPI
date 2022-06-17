using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("PriceRangeInterest")]
    public partial class PriceRangeInterest
    {
        [Column("PriceRangeID")]
        public int PriceRangeId { get; set; }
        [Column("CustomerNeedID")]
        public int CustomerNeedId { get; set; }
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey("CustomerNeedId")]
        [InverseProperty("PriceRangeInterests")]
        public virtual CustomerNeed CustomerNeed { get; set; } = null!;
        [ForeignKey("PriceRangeId")]
        [InverseProperty("PriceRangeInterests")]
        public virtual PriceRange PriceRange { get; set; } = null!;
    }
}
