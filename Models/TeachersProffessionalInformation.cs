using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class TeachersProffesionalInformation
    {
        public long Id { get; set; }
        public int YearsOfExperience { get; set; }
        public string FormerPlaceOfEmployment { get; set; }
        public string Designation { get; set; }
        public string YearOfEmployement { get; set; }
        public string YearOfDeparture { get; set; } 
        public string TeacherRegistrationNumber { get; set; } 

        //Foreign Keys 

        //[Teacher Reference]
        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; } 

        //[Referee]
        public long RefereeId { get; set; }
        public Referee Referee { get; set; }

        //[Certificates]
        public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
    }
}