using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}