using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grocery_Store.Models
{
    public class LoginEntity
    {
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
        [Display(Name ="Remember Me")]
        public Boolean RememberMe { set; get; }
    }
}