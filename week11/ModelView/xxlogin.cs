using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace week11.ModelView
{
    public class xxlogin
    {
        [Required(ErrorMessage ="Please enter email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage ="please enter password")]
        [DataType(DataType.Password)]
        public string pasword { get; set; }
    }
}
