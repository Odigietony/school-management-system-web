using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AllDepartmentsViewModel : UpdateDepartmentViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
    }
}