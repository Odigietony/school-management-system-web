using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly IEntityRepository<Course> entityRepository;
        private readonly IEntityRepository<Department> departmentRepo;
        private readonly IEntityRepository<CourseYear> courseYearRepo;
        public CourseController(IEntityRepository<Course> entityRepository, 
        IEntityRepository<Department> departmentRepo, IEntityRepository<CourseYear> courseYearRepo)
        {
            this.courseYearRepo = courseYearRepo;
            this.departmentRepo = departmentRepo;
            this.entityRepository = entityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AllCourses()
        {
            AllCoursesViewModel model = new AllCoursesViewModel();
            model.Courses = await entityRepository.GetAll().Include(c => c.CourseYear).Include(c => c.Department).ToListAsync();
            GetAllCourseYears(model);
            GetAllDepartments(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterCourse()
        {
            RegisterCourseViewModel model = new RegisterCourseViewModel();
            GetAllCourseYears(model);
            GetAllDepartments(model);
            return Redirect("allcourses");
        }

        [HttpPost]
        public IActionResult RegisterCourse(RegisterCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    CourseCode = model.CourseCode,
                    CourseName = model.CourseName,
                    CourseYearId = model.CourseYearId,
                    DepartmentId = model.DepartmentId
                };
                entityRepository.Insert(course);
                entityRepository.Save();
                return Redirect("allcourses");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateCourse(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Course resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            Course course = entityRepository.GetById(Id);
            if (course == null)
            {
                ViewBag.ErrorMessage = $"The Course with Id = { Id } could not be found";
                return View("NotFound");
            }
            UpdateCourseViewModel model = new UpdateCourseViewModel
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                CourseYearId = course.CourseYearId,
                DepartmentId = course.DepartmentId
            };
            GetAllCourseYears(model);
            GetAllDepartments(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateCourse(UpdateCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = entityRepository.GetById(model.Id);
                if (course == null)
                {
                    ViewBag.ErrorMessage = $"The Course Resource with Id = { model.Id } could not be found";
                    return View("NotFound");
                }
                course.CourseCode = model.CourseCode;
                course.CourseName = model.CourseName;
                course.CourseYearId = model.CourseYearId;
                course.DepartmentId = model.DepartmentId;
                entityRepository.Update(course);
                entityRepository.Save();
                return Json(new { success = true });
            }
            GetAllCourseYears(model);
            GetAllDepartments(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteCourse(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Course Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            Course course = entityRepository.GetById(Id);
            if (course == null)
            {
                ViewBag.ErrorMessage = $"The Course Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            entityRepository.Delete(course.Id);
            entityRepository.Save();
            return Json(new { success = true });
        }

        private RegisterCourseViewModel GetAllDepartments(RegisterCourseViewModel model)
        {
            var departments = departmentRepo.GetAll();
            foreach (var department in departments)
            {
                model.Departments.Add(new SelectListItem { Text = department.DepartmentName, Value = department.Id.ToString() });

            }
            return model;
        }

        private RegisterCourseViewModel GetAllCourseYears(RegisterCourseViewModel model)
        {
            var courseYears = courseYearRepo.GetAll();
            foreach(var year in courseYears)
            {
                model.CourseYears.Add(new SelectListItem { Text = year.YearTitle, Value = year.Id.ToString() });
            }
            return model;
        }
    }
}