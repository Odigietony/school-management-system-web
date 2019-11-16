using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AllCategories : EditCategoryViewModel
    {
        public IEnumerable<LocationCategory> Categories { get; set; }
    }
}