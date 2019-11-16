using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AllLocationsViewModel : EditLocationViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
    }
}