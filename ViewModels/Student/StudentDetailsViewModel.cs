using SchoolManagementSystem.Models;
namespace SchoolManagementSystem.ViewModels
{
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public StudentAccademicInformation StudentAccademicInformation { get; set; }
        public StudentNextOfKinInformation StudentNextOfKinInformation { get; set; }
        public StudentSponsor StudentSponsor { get; set; }
    }
}