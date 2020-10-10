using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class UserProfile
    {
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "Please enter first name")]

        public string FirstName { get; set; }
        [Display(Name = "Please enter last name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }

        public string Department { get; set; }
    }
}