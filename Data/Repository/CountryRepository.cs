using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext context;
        public CountryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteCountry(long Id)
        {
            Country country = context.Countries.Find(Id);
            context.Remove(country);
        }

        public ICollection<Country> GetAllCountries()
        {
            return context.Countries.OrderBy(s => s.CountryName).ToList();
        }

        public ICollection<State> GetRelatedStates(long Id)
        {
            return context.States.Where(s => s.CountryId == Id).ToList();
        }

        public void InsertCountry(Country country)
        {
            context.Countries.Add(country);
        }

        public void SaveCountry()
        {
            context.SaveChanges();
        }

        public Country CountryDetail(long Id)
        {
            Country country = context.Countries.Find(Id);
            return country;
        }

        public void UpdateCountry(long Id)
        {
            Country country = context.Countries.Find(Id);
            context.Attach(country);
            context.Entry(country).State = EntityState.Modified;
        }
    }
}