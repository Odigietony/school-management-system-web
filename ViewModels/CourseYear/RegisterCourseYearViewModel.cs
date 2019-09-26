using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagementSystem.ViewModels
{
    public class RegisterCourseViewModel
    {
        public RegisterCourseViewModel()
        {
            Departments = new List<SelectListItem>();
            CourseYears = new List<SelectListItem>();
        }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }


        //Drop Down Lists
        public long DepartmentId { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public long CourseYearId { get; set; }
        public List<SelectListItem> CourseYears { get; set; }
    }
}