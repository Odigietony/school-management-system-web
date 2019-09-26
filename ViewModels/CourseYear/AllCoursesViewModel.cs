using System.Collections.Generic;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class AllCoursesViewModel : UpdateCourseViewModel
    {
        public AllCoursesViewModel()
        {
            Courses = new List<Course>();
        }
        public List<Course> Courses { get; set; }
    }
}