using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AdminIndexViewModel
    {
        public IEnumerable<Admin> Admin { get; set; }
        public string PageTitle { get; set; }
    }
}