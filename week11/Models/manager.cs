using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.Models
{
    public class manager
    {
        [Required]
        [Key]
        public int managerID { get; set; }
        [Required]
        public string managerFname { get; set; }
        [Required]
        public string managerLname { get; set; }
        [Required]
        public string managerGender { get; set; }
        public virtual IdentityUser AppUser{ get; set; }
        public string AppUserID { get; set; }
    }
}
