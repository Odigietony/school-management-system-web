using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Enums
{
    public enum Religion
    {
        [Display(Name = "Christian")]
        Christian,
        [Display(Name = "Muslim")]
        Muslim,
        [Display(Name = "Buddhism")]
        Buddhism,
        [Display(Name = "Hinduism")]
        Hinduism,
        [Display(Name = "Others")]
        Others
    }
}