using System;
using SchoolManagementSystem.Enums;
namespace SchoolManagementSystem.Models
{
    public class SchoolSemester
    {
        public long Id { get; set; }
        public NameOfSemester NameOfSemester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Endate { get; set; }
    }
}