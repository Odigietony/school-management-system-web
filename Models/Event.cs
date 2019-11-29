using System;
using SchoolManagementSystem.Enums;
using System.ComponentModel.DataAnnotations;
namespace SchoolManagementSystem.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public string Image { get; set; }
        public EventGuests EventGuests { get; set; }
        public string Fee { get; set; }
        public string Sponsor { get; set; }
        public string Speaker { get; set; }

        // ForeignKeys
        public long EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }

        public long LocationId { get; set; }
        public Location Location { get; set; }
    }
}