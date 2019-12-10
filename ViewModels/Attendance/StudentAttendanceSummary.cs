using System.Collections.Generic;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentAttendanceSummary
    {
        public StudentAttendanceSummary()
        {
            StudentAttendances = new List<StudentAttendance>();
            StudentAttendanceDetails =  new List<StudentAttendanceDetail>();
        }
        public List<StudentAttendance> StudentAttendances { get; set; }
        public List<StudentAttendanceDetail> StudentAttendanceDetails { get; set; }
    }
}