using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("Image")]
    public partial class Image
    {
        [Key]
        [Column("ImageID")]
        [StringLength(100)]
        public string ImageId { get; set; } = null!;
        [Column("RentPostID")]
        [StringLength(100)]
        public string RentPostId { get; set; } = null!;
        [StringLength(100)]
        public string Url { get; set; } = null!;

        [ForeignKey("RentPostId")]
        [InverseProperty("Images")]
        public virtual RentPost RentPost { get; set; } = null!;
    }
}
