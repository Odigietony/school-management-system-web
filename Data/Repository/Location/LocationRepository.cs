using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class LocationRepository : ILocation
    {
        private readonly AppDbContext context;
        public LocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Delete(long Id)
        {
            context.Remove(Id);
        }

        public IQueryable<Location> GetAll()
        {
            return context.Locations;
        }

        public Location GetById(long Id)
        {
            return context.Locations.Find(Id);
        }

        public Location GetByTitle(string title)
        {
            return context.Locations.FirstOrDefault(l => l.Title == title);
        }

        public void Insert(Location location)
        {
            context.Locations.Add(location);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Location location)
        {
            context.Locations.Attach(location);
            context.Entry(location).State = EntityState.Modified;
        }
    }
}