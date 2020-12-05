using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.ModelView
{
    public class ModelViewRegisterTeacher
    {
        //user table
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50, ErrorMessage = "You name is too high")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "the password and confirm password do not match")]
        public string confirmPassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string UserPhone { get; set; }

        //teacher table
        [Required]
        [Display(Name = "Age")]
        public int teacherAge { get; set; }
        [Required]
        [Display(Name = "First Nmae")]
        public string teacherFirstName { get; set; }
        [Required]
        [Display(Name = "Last Nmae")]
        public string teacherLastName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string teacherGender { get; set; }
        public IFormFile teacherPic { get; set; }
    }
}
