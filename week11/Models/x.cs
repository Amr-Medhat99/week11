using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.Models
{
    public class x
    {
        [Key]
        [Required]
        public int xid { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string pasword { get; set; }
        public virtual IdentityUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
