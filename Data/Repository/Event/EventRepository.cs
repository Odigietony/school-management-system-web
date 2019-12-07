using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext context;
        public EventRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteEvent(Event events)
        {
            context.Remove(events);
        }

        public void DeleteEventCategory(EventCategory category)
        {
            context.EventCategories.Remove(category);
        }

        public IQueryable<Event> GetAll()
        {
            return context.Events.Include(e => e.Location)
            .Include(e => e.EventCategory).OrderByDescending(e => e.Id);
        }

        public IQueryable<EventCategory> GetAllEventCategories()
        {
            return context.EventCategories;
        }

        public IQueryable<Event> GetAllEventsByCategory(long categoryId)
        {
            return context.Events.Where(e => e.EventCategoryId == categoryId);
        }

        public IQueryable<Event> GetAllUpcomingEvents()
        {
            return context.Events.Where(e => e.Date <= DateTime.Now.AddDays(7));
        } 

        public Event GetEventById(long Id)
        {
            return context.Events.Find(Id);
        }

        public EventCategory GetEventCategoryById(long Id)
        {
            return context.EventCategories.Find(Id);
        }

        public EventCategory GetEventCategoryByTitle(string title)
        {
            return context.EventCategories.FirstOrDefault(ec => ec.Title == title);
        }

        public IQueryable<Event> GetTodaysEvents()
        {
            return context.Events.Where(e => e.Date == DateTime.Now.Date)
            .Include(e => e.Location).Include(e => e.EventCategory);
        }

        public void InsertEvent(Event events)
        {
            context.Events.Add(events);
        }

        public void InsertEventCategory(EventCategory category)
        {
            context.EventCategories.Add(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateEvent(Event events)
        {
            context.Events.Attach(events);
            context.Entry(events).State = EntityState.Modified;
        }

        public void UpdateEventCategory(EventCategory category)
        {
            context.EventCategories.Attach(category);
            context.Entry(category).State = EntityState.Modified;
        }
    }
}