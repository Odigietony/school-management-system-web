using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Data
{
    public static class SeedProgramYearData
    {
        public static void SeedProgramYear(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseYear>().HasData(
                new CourseYear
                {
                    Id = 0, 
                    YearTitle = "None",
                    YearNumberRepresentation = 0
                },
                new CourseYear
                {
                    Id = 1, 
                    YearTitle = "First year",
                    YearNumberRepresentation = 100
                },
                 new CourseYear
                {
                    Id = 2, 
                    YearTitle = "Second year",
                    YearNumberRepresentation = 200
                },
                 new CourseYear
                {
                    Id = 3, 
                    YearTitle = "Third year",
                    YearNumberRepresentation = 300
                },
                 new CourseYear
                {
                    Id = 4, 
                    YearTitle = "Final year",
                    YearNumberRepresentation = 400
                }
            );
        }
    }
}