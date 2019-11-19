using System.Linq;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface ILocation
    {
        IQueryable<Location> GetAll();
        void Insert(Location location);
        void Update(Location location);
        void Delete(Location location);
        void Save();
        Location GetById(long Id); 
        Location GetByTitle(string title);
        LocationCategory GetCategoryByTitle(string title);
    }
}