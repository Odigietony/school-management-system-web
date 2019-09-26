using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AllRegisteredCourseYearsViewModel : UpdateCourseYearViewModel
    {
        public AllRegisteredCourseYearsViewModel()
        {
            CourseYears = new List<CourseYear>();
        }
        public List<CourseYear> CourseYears { get; set; }
    }
}