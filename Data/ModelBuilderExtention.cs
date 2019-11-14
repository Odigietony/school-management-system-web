using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public static class ModelBuilderExtension
    {
        public static void SeedCountry(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    CountryName = "Afghanistan"
                },
                 new Country
                {
                    Id = 2,
                    CountryName = "Albania"
                },
                 new Country
                {
                    Id = 3,
                    CountryName = "Algeria"
                },
                 new Country
                {
                    Id = 4,
                    CountryName = "Andorra"
                },
                 new Country
                {
                    Id = 5,
                    CountryName = "Angola"
                },
                 new Country
                {
                    Id = 6,
                    CountryName = "Antigua and Barbuda"
                },
                 new Country
                {
                    Id = 7,
                    CountryName = "Argentina"
                },
                 new Country
                {
                    Id = 8,
                    CountryName = "Armenia"
                },
                 new Country
                {
                    Id = 9,
                    CountryName = "Australia"
                },
                 new Country
                {
                    Id = 10,
                    CountryName = "Austria"
                },
                 new Country
                {
                    Id = 11,
                    CountryName = "Azerbaijan"
                },
                 new Country
                {
                    Id = 12,
                    CountryName = "Bahamas"
                },
                 new Country
                {
                    Id = 13,
                    CountryName = "Bahrain"
                },
                 new Country
                {
                    Id = 14,
                    CountryName = "Bangladesh"
                },
                 new Country
                {
                    Id = 15,
                    CountryName = "Barbados"
                },
                 new Country
                {
                    Id = 16,
                    CountryName = "Belarus"
                },
                 new Country
                {
                    Id = 17,
                    CountryName = "Belgium"
                },
                 new Country
                {
                    Id = 18,
                    CountryName = "Belize"
                },
                 new Country
                {
                    Id = 19,
                    CountryName = "Benin"
                }, 
                new Country
                {
                 Id = 20,
                    CountryName = "Bolivia"
                },
                 new Country
                {
                    Id = 21,
                    CountryName = "Bosnia and Herzegovina"
                },
                 new Country
                {
                    Id = 22,
                    CountryName = "Botswana"
                },
                 new Country
                {
                    Id = 23,
                    CountryName = "Brazil"
                },
                 new Country
                {
                    Id = 24,
                    CountryName = "Bulgaria"
                },
                 new Country
                {
                    Id = 25,
                    CountryName = "Burkina Faso"
                },
                 new Country
                {
                    Id = 26,
                    CountryName = "Burundi"
                },
                 new Country
                {
                    Id = 27,
                    CountryName = "Côte d'Ivoire"
                },
                 new Country
                {
                    Id = 28,
                    CountryName = "Cambodia"
                },
                 new Country
                {
                    Id = 29,
                    CountryName = "Cameroon"
                },
                 new Country
                {
                    Id = 30,
                    CountryName = "Canada"
                },
                 new Country
                {
                    Id = 31,
                    CountryName = "Central African Republic"
                },
                 new Country
                {
                    Id = 32,
                    CountryName = "Chad"
                },
                 new Country
                {
                    Id = 33,
                    CountryName = "Chile"
                },
                 new Country
                {
                    Id = 34,
                    CountryName = "China"
                },
                 new Country
                {
                    Id = 35,
                    CountryName = "Colombia"
                },
                 new Country
                {
                    Id = 36,
                    CountryName = "Congo (Congo-Brazzaville)"
                },
                 new Country
                {
                    Id = 37,
                    CountryName = "Costa Rica"
                },
                 new Country
                {
                    Id = 38,
                    CountryName = "Croatia"
                },
                 new Country
                {
                    Id = 39,
                    CountryName = "Cuba"
                },
                new Country
                {
                 Id = 40,
                    CountryName = "Cyprus"
                },
                 new Country
                {
                    Id = 41,
                    CountryName = "Czechia (Czech Republic)"
                },
                 new Country
                {
                    Id = 42,
                    CountryName = "Democratic Republic of the Congo"
                },
                 new Country
                {
                    Id = 43,
                    CountryName = "Denmark"
                },
                 new Country
                {
                    Id = 44,
                    CountryName = "Dominican Republic"
                },
                 new Country
                {
                    Id = 45,
                    CountryName = "Ecuador"
                },
                 new Country
                {
                    Id = 46,
                    CountryName = "Egypt"
                },
                 new Country
                {
                    Id = 47,
                    CountryName = "El Salvador"
                },
                 new Country
                {
                    Id = 48,
                    CountryName = "Equatorial Guinea"
                },
                 new Country
                {
                    Id = 49,
                    CountryName = "Ethiopia"
                },
                 new Country
                {
                    Id = 50,
                    CountryName = "Fiji"
                },
                 new Country
                {
                    Id = 51,
                    CountryName = "Finland"
                },
                 new Country
                {
                    Id = 52,
                    CountryName = "France"
                },
                 new Country
                {
                    Id = 53,
                    CountryName = "Gabon"
                },
                 new Country
                {
                    Id = 54,
                    CountryName = "Gambia"
                },
                 new Country
                {
                    Id = 55,
                    CountryName = "Georgia"
                },
                 new Country
                {
                    Id = 56,
                    CountryName = "Germany"
                },
                 new Country
                {
                    Id = 57,
                    CountryName = "Ghana"
                },
                 new Country
                {
                    Id = 58,
                    CountryName = "Greece"
                },
                 new Country
                {
                    Id = 59,
                    CountryName = "Guinea"
                },
                new Country
                {
                    Id = 60,
                    CountryName = "Guinea-Bissau"
                },
                new Country
                {
                 Id = 61,
                    CountryName = "Haiti"
                },
                 new Country
                {
                    Id = 62,
                    CountryName = "Honduras"
                },
                 new Country
                {
                    Id = 63,
                    CountryName = "Hungary"
                },
                 new Country
                {
                    Id = 64,
                    CountryName = "Iceland"
                },
                 new Country
                {
                    Id = 65,
                    CountryName = "India"
                },
                 new Country
                {
                    Id = 66,
                    CountryName = "Indonesia"
                },
                 new Country
                {
                    Id = 67,
                    CountryName = "Iran"
                },
                 new Country
                {
                    Id = 68,
                    CountryName = "Iraq"
                },
                 new Country
                {
                    Id = 69,
                    CountryName = "Ireland"
                },
                 new Country
                {
                    Id = 70,
                    CountryName = "Israel"
                },
                 new Country
                {
                    Id = 71,
                    CountryName = "Italy"
                },
                 new Country
                {
                    Id = 72,
                    CountryName = "Jamaica"
                },
                 new Country
                {
                    Id = 73,
                    CountryName = "Japan"
                },
                 new Country
                {
                    Id = 74,
                    CountryName = "Jordan"
                },
                 new Country
                {
                    Id = 75,
                    CountryName = "Kazakhstan"
                },
                 new Country
                {
                    Id = 76,
                    CountryName = "Kenya"
                },
                 new Country
                {
                    Id = 77,
                    CountryName = "Kuwait"
                },
                 new Country
                {
                    Id = 78,
                    CountryName = "Liberia"
                },
                 new Country
                {
                    Id = 79,
                    CountryName = "Libya"
                },
                 new Country
                {
                    Id = 80,
                    CountryName = "Lithuania"
                },
                new Country
                {
                    Id = 81,
                    CountryName = "Madagascar"
                },
                new Country
                {
                    Id = 82,
                    CountryName = "Malawi"
                },
                new Country
                {
                    Id = 83,
                    CountryName = "Malaysia"
                },
                new Country
                {
                    Id = 84,
                    CountryName = "Mali"
                },
                new Country
                {
                    Id = 85,
                    CountryName = "Mauritania"
                },
                new Country
                {
                    Id = 86,
                    CountryName = "Mauritius"
                },
                new Country
                {
                    Id = 87,
                    CountryName = "Mexico"
                },
                new Country
                {
                    Id = 88,
                    CountryName = "Morocco"
                },
                new Country
                {
                    Id = 89,
                    CountryName = "Mozambique"
                },
                new Country
                {
                    Id = 90,
                    CountryName = "Myanmar (formerly Burma)"
                },
                new Country
                {
                    Id = 91,
                    CountryName = "Namibia"
                },
                new Country
                {
                    Id = 92,
                    CountryName = "Nepal"
                },
                new Country
                {
                    Id = 93,
                    CountryName = "Netherlands"
                },
                new Country
                {
                    Id = 94,
                    CountryName = "New Zealand"
                },
                new Country
                {
                    Id = 95,
                    CountryName = "Nicaragua"
                },
                new Country
                {
                    Id = 96,
                    CountryName = "Niger"
                },
                new Country
                {
                    Id = 97,
                    CountryName = "Nigeria"
                },
                new Country
                {
                    Id = 98,
                    CountryName = "North Korea"
                },
                new Country
                {
                    Id = 99,
                    CountryName = "Norway"
                },
                new Country
                {
                    Id = 100,
                    CountryName = "Oman"
                }

            );
        }
    
       
    
    }
}