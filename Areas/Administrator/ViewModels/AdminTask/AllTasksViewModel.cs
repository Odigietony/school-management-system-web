using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class AllTasksViewModel : EditTaskViewModel
    {
        // public AllTaskViewModel()
        // {
        //     AdminTask = new IEnumerable<AdminTask>();
        // }
        public IEnumerable<AdminTask> AdminTask { get; set; }
    }
}