using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Keyless]
    [Table("AreaInterest")]
    public partial class AreaInterest
    {
        [Column("AreaID")]
        public int AreaId { get; set; }
        [Column("CustomerNeedID")]
        public int CustomerNeedId { get; set; }

        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; } = null!;
        [ForeignKey("CustomerNeedId")]
        public virtual CustomerNeed CustomerNeed { get; set; } = null!;
    }
}
