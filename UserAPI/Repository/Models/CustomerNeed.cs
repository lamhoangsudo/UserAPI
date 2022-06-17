using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("CustomerNeed")]
    public partial class CustomerNeed
    {
        public CustomerNeed()
        {
            PriceRangeInterests = new HashSet<PriceRangeInterest>();
        }

        [Key]
        [Column("CustomerNeedID")]
        public int CustomerNeedId { get; set; }
        [Column("UserID")]
        [StringLength(100)]
        public string UserId { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("CustomerNeeds")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("CustomerNeed")]
        public virtual ICollection<PriceRangeInterest> PriceRangeInterests { get; set; }
    }
}
