using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.ViewModels
{
    public class AddTeacherViewModel
    {

        public AddTeacherViewModel()
        {
            Countries = new List<SelectListItem>();
            States =  new List<SelectListItem>();
        }

        //Personal Details
        [Required]
        [StringLength(20)]
        [Display(Name = "FIRST NAME")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "MIDDLE NAME")]
        public string Middlename { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "LAST NAME")]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "PERSONAL EMAIL ADDRESS")]
        public string EmailAddress { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } 

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        [Display(Name = "DATE OF BIRTH ")]
        public DateTime DateOfBirth { get; set; }  

        [Required]
        public Religion? Religion { get; set; }

        [Required]
        public Gender? Gender { get; set; }
        public IFormFile Photo { get; set; }


        //Contact Information
        [Required]
        public List<SelectListItem> Countries { get; set; }   

        [Required]  
        public List<SelectListItem> States { get; set; }

        [Required(ErrorMessage = "The Country field is required")]
        public long CountryId { get; set; }

        [Required(ErrorMessage = "The State field is required")]

        public long StateId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "HOME ADDRESS 1")]
        public string Address1 { get; set; }

        [Display(Name = "HOME ADDRESS 2")]
        [StringLength(100)]
        public string Address2 { get; set; }


        [Required]
        [Display(Name = "ZIPCODE")]
        public int ZipCode { get; set; }


        [Required]
        [Phone]
        public string HomePhone { get; set; }
        [Phone]
        public string MobilePhone { get; set; }
        [EmailAddress]
        public string AlternateEmailAddress { get; set; }
        [Required]
        [StringLength(20)]
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


        //Highest Degree Attained
        [Required]
        [Display(Name = "NAME OF INSTITUTION")]
        public string NameOfInstitution { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        public DateTime YearEnrolled { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        public DateTime YearOfGraduation { get; set; }

        [Required]
        [StringLength(4)]
        public string DegreeAttained { get; set; }

        [Required]
        public double CGPA { get; set; }


        //Teacher Preofessional Work experience 
        // [Required]
        // public int YearsOfExperience { get; set; }

        // [Required]
        // [StringLength(50)]
        // [Display(Name = "FORMER PLACE OF EMPLOYMENT")]
        // public string FormerPlaceOfEmployment { get; set; }

        // [Required]
        // [StringLength(100)]
        // [Display(Name = "ADDRESS OF FORMER PLACEMENT")]
        // public string FormerPlaceOfEmploymentAddress { get; set; }

        // [Required]
        // public string Designation { get; set; }

        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        // public DateTime YearOfEmployement { get; set; }

        // [Required]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        // public DateTime YearOfDeparture { get; set; } 

        // [Required]
        // [StringLength(8)]
        // [Display(Name = "REGISTRATION NUMBER")]
        // public string TeacherRegistrationNumber { get; set; } 


        //Other Degree
        [Required]
        public string OtherNameOfInstitution { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        public DateTime YearOfEnrollement { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyy}")]
        public DateTime OtherYearOfGraduation { get; set; }

        [Required]
        public string OtherDegreeAttained { get; set; }

        [Required]
        public double OtherCGPA { get; set; }

    }
}