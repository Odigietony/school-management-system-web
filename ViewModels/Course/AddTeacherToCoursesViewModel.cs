namespace SchoolManagementSystem.ViewModels
{
    public class AddTeacherToCoursesViewModel
    {
        public long TeacherId { get; set; }
        public string TeacherFirstname { get; set; }
        public string TeacherMiddlename { get; set; }
        public string TeacherLastname { get; set; }
        public bool IsSelected { get; set; }
    }
}