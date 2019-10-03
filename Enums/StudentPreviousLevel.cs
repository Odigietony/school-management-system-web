using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Enums
{
    public enum StudentPreviousLevel
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "First Year")]
        FirstYear,
        [Display(Name = "Second Year")]
        SecondYear,

        [Display(Name = "Third Year")]
        ThirdYear,
        [Display(Name = "Fourth Year")]
        FourthYear,
        [Display(Name = "Final Year")]
        FinalYear
        
    }
}