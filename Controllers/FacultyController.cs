using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IEntityRepository<Faculty> entityRepository;
        public FacultyController(IEntityRepository<Faculty> entityRepository)
        {
            this.entityRepository = entityRepository; 
        }

        [HttpGet]
        public IActionResult AllFaculties()
        {
            AllFacultiesViewModel model = new AllFacultiesViewModel
            {
                Faculty = entityRepository.GetAll().ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddFaculty() => Redirect("allfaculties");
        [HttpPost]
        public IActionResult AddFaculty(AddFacultyViewModel model)
        {
            if(ModelState.IsValid)
            {
                Faculty faculty = new Faculty
                {
                    FacultyCode = model.FacultyCode,
                    FacultyName = model.FacultyName
                };
                entityRepository.Insert(faculty);
                entityRepository.Save();
                return RedirectToAction("allfaculties");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditFacultyData(long Id)
        {
            Faculty faculty = entityRepository.GetById(Id);
            if(faculty == null)
            {
                ViewBag.ErrorMessage = $"The Faculty with Reference Id = { Id } could not be found";
                return View("NotFound");
            }
            EditFacultyViewModel model = new EditFacultyViewModel
            {
                Id = faculty.Id,
                FacultyCode = faculty.FacultyCode,
                FacultyName = faculty.FacultyName
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditFacultyData(EditFacultyViewModel model, long Id)
        { 
            if(ModelState.IsValid)
            { 
                Faculty faculty = entityRepository.GetById(model.Id); 
                if(faculty == null)
                {
                    ViewBag.ErrorMessage = $"The Faculty with Reference Id = {model.Id } could not be found";
                    return View("NotFound");
                }
                faculty.FacultyCode = model.FacultyCode;
                faculty.FacultyName = model.FacultyName ;
                entityRepository.Update(faculty);
                entityRepository.Save();
               return Json( new {success = true} );
            }
           return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteFacultyData(long Id)
        {
            Faculty faculty = entityRepository.GetById(Id);
            if(faculty == null)
            {
                ViewBag.ErrorMessage = $"The Faculty with Reference Id = { Id } could not be found";
                return View("NotFound");
            }
            entityRepository.Delete(faculty);
            entityRepository.Save();
            return RedirectToAction("allfaculties");
        }
    }
}