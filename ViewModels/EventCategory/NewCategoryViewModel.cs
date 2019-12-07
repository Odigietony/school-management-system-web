using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.ViewModels
{
    public class NewCategoryViewModel
    {
        [Required]
        [Remote(action: "CategoryTitleInUse", controller: "EventCategory")]
        public string Title { get; set; }
    }
}