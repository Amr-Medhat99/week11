using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.ModelView
{
    public class ModelViewStudentRegister
    {
        //user table
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50,ErrorMessage ="You name is too high")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage ="the password and confirm password do not match")]
        public string confirmPassword { get; set; }

        //student table
        [Required(ErrorMessage = "this field is require")]
        public int StudentAge { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "this field is require")]
        public string StudentGender { get; set; }
    }
}
