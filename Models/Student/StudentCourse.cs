namespace SchoolManagementSystem.Models
{
    public class StudentCourse
    {
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}