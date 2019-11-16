using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AddNewCategoryViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}