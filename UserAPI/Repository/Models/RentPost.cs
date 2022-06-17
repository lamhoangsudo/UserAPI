using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("RentPost")]
    public partial class RentPost
    {
        public RentPost()
        {
            Images = new HashSet<Image>();
        }

        [Key]
        [Column("RentPostID")]
        [StringLength(100)]
        public string RentPostId { get; set; } = null!;
        [Column("HouseID")]
        [StringLength(100)]
        public string HouseId { get; set; } = null!;
        [Column("PriceRangeID")]
        public int PriceRangeId { get; set; }
        [Column("RentPostTypeID")]
        public int RentPostTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TimePost { get; set; }
        public string Content { get; set; } = null!;

        [ForeignKey("HouseId")]
        [InverseProperty("RentPosts")]
        public virtual House House { get; set; } = null!;
        [ForeignKey("PriceRangeId")]
        [InverseProperty("RentPosts")]
        public virtual PriceRange PriceRange { get; set; } = null!;
        [ForeignKey("RentPostTypeId")]
        [InverseProperty("RentPosts")]
        public virtual RentPostType RentPostType { get; set; } = null!;
        [InverseProperty("RentPost")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
