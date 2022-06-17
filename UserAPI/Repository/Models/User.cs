using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repository.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            CustomerNeeds = new HashSet<CustomerNeed>();
            Houses = new HashSet<House>();
        }

        [Key]
        [Column("UserID")]
        [StringLength(100)]
        public string UserId { get; set; } = null!;
        [Column("RoleID")]
        public int RoleId { get; set; }
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(100)]
        public string? Phone { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        [StringLength(100)]
        public string? FirstName { get; set; }
        [StringLength(100)]
        public string? LastName { get; set; }
        public bool Status { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; } = null!;
        [InverseProperty("User")]
        public virtual ICollection<CustomerNeed> CustomerNeeds { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<House> Houses { get; set; }
    }
}
