using System.Collections.Generic; 
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AllFacultiesViewModel : EditFacultyViewModel
    {
        public AllFacultiesViewModel()
        {
            Faculty = new List<Faculty>();
        }
        public List<Faculty> Faculty { get; set; }
    }
}