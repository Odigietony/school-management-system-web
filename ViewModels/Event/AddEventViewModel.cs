using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.ViewModels
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {
            EventCategories = new List<SelectListItem>();
            Locations =  new List<SelectListItem>();
        }
        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public IFormFile Image { get; set; }
        public EventGuests EventGuests { get; set; }
        public decimal Fee { get; set; }
        public string Sponsor { get; set; }
        public string Speaker { get; set; }

        [Required]
        public long EventCategoryId { get; set; }
        public List<SelectListItem> EventCategories { get; set; }

        [Required]
        public long LocationId { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}