namespace SchoolManagementSystem.Areas.Administrator.ViewModels
{
    public class DashboardViewModel
    {
        public long AllActiveStudents { get; set; }
        public long AllTeachers { get; set; }
        public long AllEvents { get; set; }
        public long AllMessages { get; set; }
        public IList<Task> TodaysTasks { get; set; }
    }
}