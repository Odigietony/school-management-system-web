using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public long Id { get; set; }

        [Required]
        public string MatriculationNumber { get; set; }

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
        public string ProfilePhotoPath { get; set; }

        //Contact Information
        [Required]
        public string ResidentialAddress { get; set; }
        public string ContactAddress { get; set; }
        [EmailAddress]
        public string AlternateEmailAddress { get; set; } 

        //Foreign Keys
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        //=== Programe Information === //
        // These will be used to auto set student faculty and department and courses as well.
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public long CourseYearId { get; set; }
        public CourseYear CourseYear { get; set; }
        public virtual List<StudentCourse> StudentCourse { get; set; }

    }
}