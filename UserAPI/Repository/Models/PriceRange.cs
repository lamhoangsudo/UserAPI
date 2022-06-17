using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("PriceRange")]
    public partial class PriceRange
    {
        public PriceRange()
        {
            PriceRangeInterests = new HashSet<PriceRangeInterest>();
            RentPosts = new HashSet<RentPost>();
        }

        [Key]
        [Column("PriceRangeID")]
        public int PriceRangeId { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }

        [InverseProperty("PriceRange")]
        public virtual ICollection<PriceRangeInterest> PriceRangeInterests { get; set; }
        [InverseProperty("PriceRange")]
        public virtual ICollection<RentPost> RentPosts { get; set; }
    }
}
