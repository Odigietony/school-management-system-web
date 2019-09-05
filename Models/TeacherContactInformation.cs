using System.ComponentModel.DataAnnotations;
using SchoolManagementSystem.Enums;

namespace SchoolManagementSystem.Models
{
    public class TeacherContactInformation
    {
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; }
        [Required] 
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

        //Foreign Keys 
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public long CountryId { get; set; }
        public Country Country { get; set; }
    }
}