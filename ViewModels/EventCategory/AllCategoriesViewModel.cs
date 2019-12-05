using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AllCategoriesViewModel : EditEventCategoryViewModel
    {
        public AllCategoriesViewModel()
        {
            EventCategories = new List<EventCategory>();
        }
        public List<EventCategory> EventCategories { get; set; }
    }
}