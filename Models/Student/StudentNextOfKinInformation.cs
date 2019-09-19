using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class StudentNextOfKinInformation
    {
        public long Id { get; set; }
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

        //Foreign Keys
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}