using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels
{
    public class AddFacultyViewModel
    {
        [Required(ErrorMessage = "Faculty Code is Required")]
        [Range(01, 10)]
        public int FacultyCode { get; set; }
        [Required(ErrorMessage = "Faculty Name is Required")]
        public string FacultyName { get; set; }
    }
}