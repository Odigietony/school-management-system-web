using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Enums
{
    public enum AttendanceStatus
    {
        [Display(Name = "Absent")]
        Absent,

        [Display(Name = "Present")]
        Present
    }
}