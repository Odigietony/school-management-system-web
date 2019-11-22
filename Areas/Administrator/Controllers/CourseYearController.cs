using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Areas.Administrator.ViewModels;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CourseYearController : Controller
    {
        private readonly IEntityRepository<CourseYear> entityRepository;
        public CourseYearController(IEntityRepository<CourseYear> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        [HttpGet]
        public IActionResult AllRegisteredCourseYears()
        {
            AllRegisteredCourseYearsViewModel model = new AllRegisteredCourseYearsViewModel();
            model.CourseYears = entityRepository.GetAll().ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult CourseYearRegistration() => Redirect("allregisterdcourseyears");

        [HttpPost]
        public IActionResult CourseYearRegistration(CourseYearRegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                CourseYear courseYear = new CourseYear
                {
                    YearTitle = model.YearTitle,
                    YearNumberRepresentation = model.YearNumberRepresentation
                };
                entityRepository.Insert(courseYear);
                entityRepository.Save();
                TempData["created"] = $"Admin { model.YearTitle }, was created successfully.";
                return RedirectToAction("allregisteredcourseyears");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateCourseYear(long Id)
        {
            if(Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The course year resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            CourseYear courseYear = entityRepository.GetById(Id);
            if(courseYear == null)
            {
                ViewBag.ErrorMessage = $"The course year with Id = { Id } could not be found";
                return View("NotFound");
            }
            UpdateCourseYearViewModel model = new UpdateCourseYearViewModel
            {
                Id = courseYear.Id,
                YearTitle =  courseYear.YearTitle,
                YearNumberRepresentation = courseYear.YearNumberRepresentation
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateCourseYear(UpdateCourseYearViewModel model)
        {
            if(ModelState.IsValid)
            {
                CourseYear courseYear = entityRepository.GetById(model.Id);
                if(courseYear == null)
                {
                    ViewBag.ErrorMessage = $"The course year with Id = { model.Id } could not be found";
                    return View("NotFound");
                }
                courseYear.YearTitle = model.YearTitle;
                courseYear.YearNumberRepresentation = model.YearNumberRepresentation;
                entityRepository.Update(courseYear);
                entityRepository.Save();
                TempData["edited"] = $"Year { model.YearTitle }, was updated successfully.";
                return Json(new { success = true });
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteCourseYear(long Id)
        {
             if(Id.Equals(0))
            {
               ViewBag.ErrorMessage = $"The Faculty with Reference Id = { Id } could not be found";
               return View("NotFound");
            } 
            else
            {
                CourseYear courseYear = entityRepository.GetById(Id);
                if(courseYear == null)
                {
                    ViewBag.ErrorMessage = $"The course Year with Reference Id = { Id } could not be found";
                    return View("NotFound");
                }
                string course_year = courseYear.YearTitle;
                entityRepository.Delete(courseYear.Id);
                entityRepository.Save();
                TempData["deleted"] = $"Year { course_year }, was permanently deleted";
                return Json(new {success = true });
            }
        }

    }
}