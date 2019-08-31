using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Enums
{
    public enum RelationToNextOfKin
    {
        [Display(Name = "Father")]
        Father,
        [Display(Name = "Mother")]
        Mother,
        [Display(Name = "Brother")]
        Brother,
        [Display(Name = "Sister")]
        Sister,
        [Display(Name = "Uncle")]
        Uncle,
        [Display(Name = "Aunt")]
        Aunt,
        [Display(Name = "Husband")]
        Husband,
        [Display(Name = "Wife")]
        Wife

    }
}