using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AdminDetailsViewModel
    {
        public AdminDetailsViewModel()
        {
            Roles = new List<string>();
        }
        public Admin Admin { get; set; }

        public IList<string> Roles { get; set; }
    }
}