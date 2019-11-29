using SchoolManagementSystem.Models;
using System.Linq;
namespace SchoolManagementSystem.Data.Repository
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAll();
        IQueryable<Event> GetAllEventsByCategory(long categoryId);
        IQueryable<Event> GetTodaysEvents();
        IQueryable<Event> GetAllUpcomingEvents();
        Event GetEventById(long Id);
        void InsertEvent(Event e);
        void UpdateEvent(Event e);
        void DeleteEvent(Event e);
        IQueryable<EventCategory> GetAllEventCategories();
        EventCategory GetEventCategoryById(long Id);
        EventCategory GetEventCategoryByTitle(string title);
        void InsertEventCategory(EventCategory category);
        void UpdateEventCategory(EventCategory category);
        void DeleteEventCategory(EventCategory category);
        
        void Save();


    }
}