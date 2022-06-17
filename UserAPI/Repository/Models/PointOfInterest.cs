using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("PointOfInterest")]
    public partial class PointOfInterest
    {
        public PointOfInterest()
        {
            ApartmentInterests = new HashSet<ApartmentInterest>();
        }

        [Key]
        [Column("PointOfInterestID")]
        public int PointOfInterestId { get; set; }
        [Column("PointOfInterestTypeID")]
        public int PointOfInterestTypeId { get; set; }
        [Column("AreaID")]
        public int? AreaId { get; set; }

        [ForeignKey("AreaId")]
        [InverseProperty("PointOfInterests")]
        public virtual Area? Area { get; set; }
        [ForeignKey("PointOfInterestTypeId")]
        [InverseProperty("PointOfInterests")]
        public virtual PointOfInterestType PointOfInterestType { get; set; } = null!;
        [InverseProperty("PointOfInterest")]
        public virtual ICollection<ApartmentInterest> ApartmentInterests { get; set; }
    }
}
