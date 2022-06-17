using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("RentPostType")]
    public partial class RentPostType
    {
        public RentPostType()
        {
            RentPosts = new HashSet<RentPost>();
        }

        [Key]
        [Column("RentPostTypeID")]
        public int RentPostTypeId { get; set; }
        [StringLength(50)]
        public string Type { get; set; } = null!;

        [InverseProperty("RentPostType")]
        public virtual ICollection<RentPost> RentPosts { get; set; }
    }
}
