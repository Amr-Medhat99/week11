using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.Models
{
    public class student
    {
        [Key]
        [Required(ErrorMessage = "this field is require")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "this field is require")]
        public int StudentAge { get; set; }
        [Required]
        [StringLength(6,MinimumLength =4,ErrorMessage ="this field is require")]
        public string StudentGender { get; set; }
        //navigation property
        public virtual IdentityUser AppUser { get; set; }
        public string AppUserId { get; set; }

    }
}
