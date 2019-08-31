using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Referee
    {
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(20)]
        public string Designation { get; set; }
        [Required]
        [StringLength(20)]
        public string Organisation { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        //foreign Keys
        public long TeacherId { get; set; }
    }
}