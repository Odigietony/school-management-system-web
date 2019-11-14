using System;
using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{
    public class TeacherTask
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}