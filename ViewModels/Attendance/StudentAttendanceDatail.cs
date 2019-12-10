using System;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentAttendanceDetail
    {
        public long CourseCode { get; set; }
        public DateTime LastClassAttendance { get; set; }
        public long TotalClasses { get; set; }
        public long ClassesAttendend { get; set; }
        public decimal Percentage { get; set; }
    }
}