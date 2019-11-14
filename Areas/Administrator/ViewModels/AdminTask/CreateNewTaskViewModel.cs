using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class CreateNewTaskViewModel
    {
        public CreateNewTaskViewModel()
        {
            Locations = new List<SelectListItem>();
        }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public long LocationId { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}