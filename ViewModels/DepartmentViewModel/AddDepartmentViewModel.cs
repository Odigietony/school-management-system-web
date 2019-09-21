using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.ViewModels
{
    public class AddDepartmentViewModel
    {
        public AddDepartmentViewModel()
        {
            Faculties = new List<SelectListItem>();
        }
        [Required]
        public int DepartmentCode { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "The Faculty Field is required")]
        public long FacultyId { get; set; }
        public List<SelectListItem> Faculties { get; set; }
    }
}