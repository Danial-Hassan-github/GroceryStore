using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Grocery_Store.Models
{
    public class SignupEntity
    {
        public int id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public string Contact { set; get; }
        [Required]
        public string Address { set; get; }
    }
}