using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using BlogMVC.Models;

namespace BlogMVC.ViewModels
{
	public class RegisterViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

	}
}

