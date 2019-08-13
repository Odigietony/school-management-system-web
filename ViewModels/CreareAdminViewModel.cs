using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class CreateAdminViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Admin")]
        public string EmailAddress { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public IFormFile Image { get; set; }
        public IdentityRole Role { get; set; }
    }
}