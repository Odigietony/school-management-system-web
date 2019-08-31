using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Enums
{
    public enum Gender
    {
        [Display(Name ="Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Others")]
        Others
    }
}