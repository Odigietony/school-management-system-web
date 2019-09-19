using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class StudentSponsor
    {
        public long Id { get; set; }
        [Required]
        [StringLength(30)]
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

        //Foreign Keys
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}