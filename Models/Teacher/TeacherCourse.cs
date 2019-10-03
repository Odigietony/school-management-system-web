namespace SchoolManagementSystem.Models
{
    public class TeacherCourse
    {
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public long CourseId { get; set; }
        public Course Course { get; set; }
    }
}