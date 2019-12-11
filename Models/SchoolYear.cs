using System;
namespace SchoolManagementSystem.Models
{
    public class SchoolYear
    {
        public long Id {get; set;}
        public string NameOfSeason { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set;}
    }
}