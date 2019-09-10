using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class TeacherDetailsViewModel
    {
        public Teacher Teacher { get; set; }
        public TeacherContactInformation TeacherContactInformation { get; set; }
        public TeacherHighestDegree TeacherHighestDegree { get; set; }
        public TeacherOtherDegree TeacherOtherDegree { get; set; }
    }
}