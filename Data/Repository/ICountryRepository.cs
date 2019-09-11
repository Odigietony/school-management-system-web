using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data.Repository
{
    public interface ICountryRepository
    {
        void InsertCountry(Country country);
        void DeleteCountry(long Id); 
        void UpdateCountry(long Id);
        Country CountryDetail(long Id);
        void SaveCountry();
        ICollection<State> GetRelatedStates(long Id);
        ICollection<Country> GetAllCountries();
        Country GetCountryById(long countryId);
    }
}