using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public static class SeedStateData
    {
         public static void SeedStates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new State
                {
                    Id = 1,
                    StateName = "Kabul",
                    CountryId = 1
                },
                new State
                {
                    Id = 2,
                    StateName = "Kandahar",
                    CountryId = 1
                },
                new State
                {
                    Id = 3,
                    StateName = "Herat",
                    CountryId = 1
                },
                new State
                {
                    Id = 4,
                    StateName = "Mazar-i-Sharif",
                    CountryId = 1
                },
                new State
                {
                    Id = 5,
                    StateName = "Kabul",
                    CountryId = 1
                },
                new State
                {
                    Id = 6,
                    StateName = "Jalalabad",
                    CountryId = 1
                },
                new State
                {
                    Id = 7,
                    StateName = "Kunduz",
                    CountryId = 1
                },
                new State
                {
                    Id = 8,
                    StateName = "Ghazni",
                    CountryId = 1
                },
                new State
                {
                    Id = 9,
                    StateName = "Lashkargah",
                    CountryId = 1
                },
                new State
                {
                    Id = 10,
                    StateName = "Taloqan",
                    CountryId = 1
                },
                new State
                {
                    Id = 11,
                    StateName = "Tirana",
                    CountryId = 2
                },
                new State
                {
                    Id = 12,
                    StateName = "Durrës",
                    CountryId = 2
                },
                new State
                {
                    Id = 13,
                    StateName = "Vlorë",
                    CountryId = 2
                },
                new State
                {
                    Id = 14,
                    StateName = "Elbasan",
                    CountryId = 2
                },
                new State
                {
                    Id = 15,
                    StateName = "Shkodër",
                    CountryId = 2
                },
                new State
                {
                    Id = 16,
                    StateName = "Fier",
                    CountryId = 2
                },
                new State
                {
                    Id = 17,
                    StateName = "Kamëz",
                    CountryId = 2
                },
                new State
                {
                    Id = 18,
                    StateName = "Korçë",
                    CountryId = 2
                },
                new State
                {
                    Id = 19,
                    StateName = "Berat",
                    CountryId = 2
                },
                new State
                {
                    Id = 20,
                    StateName = "Lushnjë",
                    CountryId = 2
                },
                new State
                {
                    Id = 21,
                    StateName = "Algiers",
                    CountryId = 3
                },
                 new State
                {
                    Id = 22,
                    StateName = "Oran",
                    CountryId = 3
                },
                new State
                {
                    Id = 23,
                    StateName = "Constantine",
                    CountryId = 3
                },
                new State
                {
                    Id = 24,
                    StateName = "Annaba",
                    CountryId = 3
                },
                new State
                {
                    Id = 25,
                    StateName = "Blida",
                    CountryId = 3
                },
                new State
                {
                    Id = 26,
                    StateName = "Batna",
                    CountryId = 3
                },
                new State
                {
                    Id = 27,
                    StateName = "Djelfa",
                    CountryId = 3
                },
                new State
                {
                    Id = 28,
                    StateName = "Sétif",
                    CountryId = 3
                },
                new State
                {
                    Id = 29,
                    StateName = "Sidi Bel Abbès",
                    CountryId = 3
                },
                new State
                {
                    Id = 30,
                    StateName = "Biskra",
                    CountryId = 3
                },
                 new State
                {
                    Id = 31,
                    StateName = "Canillo",
                    CountryId = 4
                },
                new State
                {
                    Id = 32,
                    StateName = "L'Aldosa",
                    CountryId = 4
                },
                new State
                {
                    Id = 33,
                    StateName = "L'Armiana",
                    CountryId = 4
                },
                new State
                {
                    Id = 34,
                    StateName = "Bordes d'Envalira",
                    CountryId = 4
                },
                new State
                {
                    Id = 35,
                    StateName = "El Forn",
                    CountryId = 4
                },
                new State
                {
                    Id = 36,
                    StateName = "Incles",
                    CountryId = 4
                },
                new State
                {
                    Id = 37,
                    StateName = "Meritxell",
                    CountryId = 4
                },
                new State
                {
                    Id = 38,
                    StateName = "Molleres",
                    CountryId = 4
                },
                new State
                {
                    Id = 39,
                    StateName = "Els Plans",
                    CountryId = 4
                },
                new State
                {
                    Id = 40,
                    StateName = "Prats",
                    CountryId = 4
                },
                new State
                {
                    Id = 41,
                    StateName = "Ambriz",
                    CountryId = 5
                },
                new State
                {
                    Id = 42,
                    StateName = "Andulo",
                    CountryId = 5
                },
                new State
                {
                    Id = 43,
                    StateName = "Bailundo",
                    CountryId = 5
                },
                new State
                {
                    Id = 44,
                    StateName = "Balombo",
                    CountryId = 5
                },
                new State
                {
                    Id = 45,
                    StateName = "Baía Farta",
                    CountryId = 5
                },
                new State
                {
                    Id = 46,
                    StateName = "Benguela",
                    CountryId = 5
                },
                new State
                {
                    Id = 47,
                    StateName = "Bibala (Vila Arriaga)",
                    CountryId = 5
                },
                new State
                {
                    Id = 48,
                    StateName = "Bimbe",
                    CountryId = 5
                },
                new State
                {
                    Id = 49,
                    StateName = "Biula",
                    CountryId = 5
                },
                new State
                {
                    Id = 50,
                    StateName = "Bungo",
                    CountryId = 5
                },
                new State
                {
                    Id = 51,
                    StateName = "All Saints",
                    CountryId = 6
                },
                 new State
                {
                    Id = 52,
                    StateName = "Bolans",
                    CountryId = 6
                },
                new State
                {
                    Id = 53,
                    StateName = "Carlisle, Saint George",
                    CountryId = 6
                },
                new State
                {
                    Id = 54,
                    StateName = "Carlisle, Saint Philip",
                    CountryId = 6
                },
                new State
                {
                    Id = 55,
                    StateName = "Clare Hall",
                    CountryId = 6
                },
                new State
                {
                    Id = 56,
                    StateName = "Cedar Grove",
                    CountryId = 6
                },
                new State
                {
                    Id = 57,
                    StateName = "Codrington",
                    CountryId = 6
                },
                new State
                {
                    Id = 58,
                    StateName = "Dickenson Bay",
                    CountryId = 6
                },
                new State
                {
                    Id = 59,
                    StateName = "English Harbour",
                    CountryId = 6
                },
                new State
                {
                    Id = 60,
                    StateName = "Falmouth",
                    CountryId = 6
                },
                 new State
                {
                    Id = 61,
                    StateName = "Buenos Aires",
                    CountryId = 7
                },
                new State
                {
                    Id = 62,
                    StateName = "Catamarca",
                    CountryId = 7
                },
                new State
                {
                    Id = 63,
                    StateName = "Chaco",
                    CountryId = 7
                },
                new State
                {
                    Id = 64,
                    StateName = "Chubut",
                    CountryId = 7
                },
                new State
                {
                    Id = 65,
                    StateName = "Cordoba",
                    CountryId = 7
                },
                new State
                {
                    Id = 66,
                    StateName = "Currents",
                    CountryId = 7
                },
                new State
                {
                    Id = 67,
                    StateName = "Between Rivers",
                    CountryId = 7
                },
                new State
                {
                    Id = 68,
                    StateName = "Formosa",
                    CountryId = 7
                },
                new State
                {
                    Id = 69,
                    StateName = "Jujuy",
                    CountryId = 7
                },
                new State
                {
                    Id = 70,
                    StateName = "La Pampa",
                    CountryId = 7
                },
                new State
                {
                    Id = 71,
                    StateName = "Aragatsotn",
                    CountryId = 8
                },
                new State
                {
                    Id = 72,
                    StateName = "Ararat",
                    CountryId = 8
                },
                new State
                {
                    Id = 73,
                    StateName = "Armavir",
                    CountryId = 8
                },
                new State
                {
                    Id = 74,
                    StateName = "Gegharkunik",
                    CountryId = 8
                },
                new State
                {
                    Id = 75,
                    StateName = "Kotayk",
                    CountryId = 8
                },
                new State
                {
                    Id = 76,
                    StateName = "Lori",
                    CountryId = 8
                },
                new State
                {
                    Id = 77,
                    StateName = "Shirak",
                    CountryId = 8
                },
                new State
                {
                    Id = 78,
                    StateName = "Syunik",
                    CountryId = 8
                },
                new State
                {
                    Id = 79,
                    StateName = "Tavush",
                    CountryId = 8
                },
                new State
                {
                    Id = 80,
                    StateName = "Vayots Dzor",
                    CountryId = 8
                },
                new State
                {
                    Id = 81,
                    StateName = "Sydney",
                    CountryId = 9
                },
                 new State
                {
                    Id = 82,
                    StateName = "Melbourne",
                    CountryId = 9
                },
                new State
                {
                    Id = 83,
                    StateName = "Brisbane",
                    CountryId = 9
                },
                new State
                {
                    Id = 84,
                    StateName = "Perth",
                    CountryId = 9
                },
                new State
                {
                    Id = 85,
                    StateName = "Adelaide",
                    CountryId = 9
                },
                new State
                {
                    Id = 86,
                    StateName = "Gold Coast–Tweed Heads",
                    CountryId = 9
                },
                new State
                {
                    Id = 87,
                    StateName = "Newcastle–Maitland",
                    CountryId = 9
                },
                new State
                {
                    Id = 88,
                    StateName = "Canberra–Queanbeyan",
                    CountryId = 9
                },
                new State
                {
                    Id = 89,
                    StateName = "Sunshine Coast",
                    CountryId = 9
                },
                new State
                {
                    Id = 90,
                    StateName = "Wollongong",
                    CountryId = 9
                },
                 new State
                {
                    Id = 91,
                    StateName = "Vienna",
                    CountryId = 10
                },
                new State
                {
                    Id = 92,
                    StateName = "Graz",
                    CountryId = 10
                },
                new State
                {
                    Id = 93,
                    StateName = "Linz",
                    CountryId = 10
                },
                new State
                {
                    Id = 94,
                    StateName = "Salzburg",
                    CountryId = 10
                },
                new State
                {
                    Id = 95,
                    StateName = "Innsbruck",
                    CountryId = 10
                },
                new State
                {
                    Id = 96,
                    StateName = "Klagenfurt",
                    CountryId = 10
                },
                new State
                {
                    Id = 97,
                    StateName = "Villach",
                    CountryId = 10
                },
                new State
                {
                    Id = 98,
                    StateName = "Wels",
                    CountryId = 10
                },
                new State
                {
                    Id = 99,
                    StateName = "Sankt Pölten",
                    CountryId = 10
                },
                new State
                {
                    Id = 100,
                    StateName = "Dornbirn",
                    CountryId = 10
                },
                new State
                {
                    Id = 101,
                    StateName = "Agdash",
                    CountryId = 11
                },
                new State
                {
                    Id = 102,
                    StateName = "Agjabadi",
                    CountryId = 11
                },
                new State
                {
                    Id = 103,
                    StateName = "Agstafa",
                    CountryId = 11
                },
                new State
                {
                    Id = 104,
                    StateName = "Agsu",
                    CountryId = 11
                },
                new State
                {
                    Id = 105,
                    StateName = "Astara",
                    CountryId = 11
                },
                new State
                {
                    Id = 106,
                    StateName = "Babek",
                    CountryId = 11
                },
                new State
                {
                    Id = 107,
                    StateName = "Baku",
                    CountryId = 11
                },
                new State
                {
                    Id = 108,
                    StateName = "Balakən",
                    CountryId = 11
                },
                new State
                {
                    Id = 109,
                    StateName = "Barda",
                    CountryId = 11
                },
                new State
                {
                    Id = 110,
                    StateName = "Beylagan",
                    CountryId = 11
                },
                new State
                {
                    Id = 111,
                    StateName = "Nassau",
                    CountryId = 12
                },
                 new State
                {
                    Id = 112,
                    StateName = "Freeport",
                    CountryId = 12
                },
                new State
                {
                    Id = 113,
                    StateName = "West End",
                    CountryId = 12
                },
                new State
                {
                    Id = 114,
                    StateName = "Coopers Town",
                    CountryId = 12
                },
                new State
                {
                    Id = 115,
                    StateName = "Marsh Harbour",
                    CountryId = 12
                },
                new State
                {
                    Id = 116,
                    StateName = "Freetown",
                    CountryId = 12
                },
                new State
                {
                    Id = 117,
                    StateName = "Bahamas City",
                    CountryId = 12
                },
                new State
                {
                    Id = 118,
                    StateName = "Andros Town",
                    CountryId = 12
                },
                new State
                {
                    Id = 119,
                    StateName = "Clarence Town",
                    CountryId = 12
                },
                new State
                {
                    Id = 120,
                    StateName = "Dunmore Town",
                    CountryId = 12
                }

            );
        }
    }
}