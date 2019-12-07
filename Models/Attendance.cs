using System;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class Attendance
    {
        public long Id { get; set; }
        public AttendanceStatus IsPresent { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }

        //Foreign Keys
        // [Student]
        public long StudentId { get; set; } 
        public Student Student { get; set; }

        // [Course]
        public long CourseId { get; set; }
        public Course Course { get; set; }

        // [CourseYear]
        public long CourseYearId { get; set; }
        public CourseYear CourseYear { get; set; }
    }
}