using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.Models
{
    public class teacher
    {
        [Required]
        [Key]
        public int teacherID { get; set; }
        [Required]
        [Display(Name ="Age")]
        public int teacherAge { get; set; }
        [Required]
        [Display(Name ="First Nmae")]
        public string teacherFirstName { get; set; }
        [Required]
        [Display(Name = "Last Nmae")]
        public string teacherLastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string teacherGender { get; set; }
        public virtual IdentityUser AppUser { get; set; }
        public string AppUserId{ get; set; }

    }
}
