using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class DashboardViewModel
    {
        public long AllActiveStudents { get; set; }
        public long AllTeachers { get; set; }
        public long AllEvents { get; set; }
        public long AllMessages { get; set; }
        public IList<AdminTask> TodaysTasks { get; set; }
    }
}