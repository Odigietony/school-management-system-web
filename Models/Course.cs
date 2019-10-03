using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public class Course
    {
        public long Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        //Foreign Keys
        public long CourseYearId { get; set; }
        public CourseYear CourseYear { get; set; }

        public long DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<TeacherCourse> TeacherCourse { get; set; }
        public virtual List<StudentCourse> StudentCourse { get; set; }
    }
}