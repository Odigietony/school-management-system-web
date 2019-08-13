using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models
{
    public class Admin
    {
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        public string ImagePath { get; set; }

        //Foreign Key to User table
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        
    }
}