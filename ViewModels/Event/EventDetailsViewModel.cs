using SchoolManagementSystem.Models;
namespace SchoolManagementSystem.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event GetEvent { get; set; }
        public Location EventLocation { get; set; }
        public EventCategory EventCat { get; set; }
    }
}