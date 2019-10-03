using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class StudentAccademicInformation
    {
        public long Id { get; set; }
        public string NameOfInstitution { get; set; }
        public string YearEnrolled { get; set; }
        public string YearOfGraduation { get; set; }
        [Required]
        public StudentPreviousLevel? PreviousLevel { get; set; } // this will be used to set a student to a courseYear.

        //Foreign Key
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}