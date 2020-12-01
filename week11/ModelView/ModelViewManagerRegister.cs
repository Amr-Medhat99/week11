using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.ModelView
{
    public class ModelViewManagerRegister
    {
        [Required]
        [Display(Name = "First Name")]
        public string managerFname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string managerLname { get; set; }
        //user table
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
        [Display(Name = "Gender")]
        public string managerGender { get; set; }
    }
}
