using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
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

        [Remote(action: "IsEmailInUse", controller: "Admin", ErrorMessage="Email is already in use.")]
        [Required]
        [EmailAddress] 
        public string EmailAddress { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        // [DataType(DataType.Password)]
        public string Password { get; set; }

        public IFormFile Image { get; set; }
        public IdentityRole Role { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}