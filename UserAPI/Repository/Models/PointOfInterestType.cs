using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("PointOfInterestType")]
    public partial class PointOfInterestType
    {
        public PointOfInterestType()
        {
            PointOfInterests = new HashSet<PointOfInterest>();
        }

        [Key]
        [Column("PointOfInterestTypeID")]
        public int PointOfInterestTypeId { get; set; }
        [StringLength(100)]
        public string Type { get; set; } = null!;

        [InverseProperty("PointOfInterestType")]
        public virtual ICollection<PointOfInterest> PointOfInterests { get; set; }
    }
}
