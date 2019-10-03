using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.ViewModels
{
    public class AddStudentViewModel
    {
        public AddStudentViewModel()
        {
            CourseYears = new List<SelectListItem>();
            Departments = new List<SelectListItem>();
            Faculties = new List<SelectListItem>();
        }
        
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; } 
        [StringLength(20)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Phone]
        public string AlternatePhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public Religion? Religion { get; set; }
        [Required]
        public MaritalStatus? MaritalStatus { get; set; }
        public IFormFile Image { get; set; }

        //Contact Information
        [Required]
        public string ResidentialAddress { get; set; }
        public string ContactAddress { get; set; }
        [EmailAddress]
        public string AlternateEmailAddress { get; set; }  

        //=== Programe Information === //
        // These will be used to auto set student faculty and department and courses as well.
        [Required]
        public long DepartmentId { get; set; }
        public List<SelectListItem> Departments { get; set; }

        [Required]
        public long FacultyId { get; set; }
        public List<SelectListItem> Faculties { get; set; }

        [Required]
        public long CourseYearId { get; set; }
        public List<SelectListItem> CourseYears { get; set; }



        // Student Accademic information
        public string NameOfInstitution { get; set; }
        public string YearEnrolled { get; set; }
        public string YearOfGraduation { get; set; }
        [Required]
        public StudentPreviousLevel? PreviousLevel { get; set; }


        // Student Next of Kin
        public string NextOfKinFirstname { get; set; }
        [Required]
        [StringLength(20)]
        public string NextOfKinLastname { get; set; }
        [Required]
        public RelationToNextOfKin? RelationToNextOfKin { get; set; }
        [Required]
        [Phone]
        public string PhoneOfNextOfKin { get; set; }
        [Required]
        [EmailAddress]
        public string EmailOfNextOfKin { get; set; }

        // Student Sponsor
        public string SponsorFirstname { get; set; } 
        [StringLength(30)]
        public string SponsorMiddlename{ get; set; } 
        [Required]
        [StringLength(30)]
        public string SponsorLastname { get; set; }
        [Required]
        [EmailAddress]
        public string SponsorEmailAddress { get; set; }
        [Required]
        [Phone]
        public string SponsorPhoneNumber { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string SponsorContactAddress { get; set; }
        [Required]
        public string SponsorProffession { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string SponsorWorkAddress { get; set; }
    }
}