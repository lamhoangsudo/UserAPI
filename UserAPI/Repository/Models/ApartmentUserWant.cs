using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Keyless]
    [Table("ApartmentUserWant")]
    public partial class ApartmentUserWant
    {
        [Column("ApartmentID")]
        [StringLength(100)]
        public string ApartmentId { get; set; } = null!;
        [Column("CustomerNeedID")]
        public int CustomerNeedId { get; set; }

        [ForeignKey("ApartmentId")]
        public virtual Apartment Apartment { get; set; } = null!;
        [ForeignKey("CustomerNeedId")]
        public virtual CustomerNeed CustomerNeed { get; set; } = null!;
    }
}
