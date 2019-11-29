using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Enums
{
    public enum EventGuests
    {
        [Display(Name = "Students Only")]
        StudentsOnly,
        [Display(Name = "Staff Only")]
        StaffOnly,
        [Display(Name = "Parents Only")]
        ParentsOnly,
        [Display(Name = "Everyone")]
        Everyone

    }
}