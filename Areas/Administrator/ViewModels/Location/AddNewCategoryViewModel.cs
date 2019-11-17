using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AddNewCategoryViewModel
    {
        [Required]
        [Remote(action: "LocationCategoryInUse", controller: "Location", areaName: "Administrator")]
        public string Title { get; set; }
    }
}