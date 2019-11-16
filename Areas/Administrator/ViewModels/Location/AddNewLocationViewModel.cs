using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AddNewLocationViewModel
    {
        public AddNewLocationViewModel()
        {
            Categories = new List<SelectListItem>();
        }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        public long Number { get; set; }
        public long CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}