using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("Area")]
    public partial class Area
    {
        public Area()
        {
            PointOfInterests = new HashSet<PointOfInterest>();
        }

        [Key]
        [Column("AreaID")]
        public int AreaId { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [InverseProperty("Area")]
        public virtual ICollection<PointOfInterest> PointOfInterests { get; set; }
    }
}
