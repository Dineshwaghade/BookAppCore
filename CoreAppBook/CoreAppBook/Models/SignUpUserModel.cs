using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppBook.Models
{
    public class SignUpUserModel
    {
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public  string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Enter valid email address")]
        [Display(Name ="Email address")]
        public String Email { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        public String Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
    }
}
