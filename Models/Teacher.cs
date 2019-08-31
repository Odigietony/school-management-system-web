using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
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
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public Religion? Religion { get; set; }
        public string ProfilePhotoPath { get; set; }

        //Foreign Key
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}