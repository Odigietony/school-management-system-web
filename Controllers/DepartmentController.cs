using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IEntityRepository<Department> entityRepository;
        private readonly IEntityRepository<Faculty> facultyRepo;
        public DepartmentController(IEntityRepository<Department> entityRepository, IEntityRepository<Faculty> facultyRepo)
        {
            this.facultyRepo = facultyRepo;
            this.entityRepository = entityRepository;
        }

        [HttpGet]
        public IActionResult AllDepartments()
        {
            AllDepartmentsViewModel model = new AllDepartmentsViewModel();
            model.Departments = entityRepository.GetAll().Include(d => d.Faculty);
            GetAllFaculties(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            AddDepartmentViewModel model = new AddDepartmentViewModel();
            GetAllFaculties(model);
            return RedirectToAction("alldepartments", model);
        }

        private AddDepartmentViewModel GetAllFaculties(AddDepartmentViewModel model)
        {
            var faculties = facultyRepo.GetAll();
            foreach(var faculty in faculties)
            {
                model.Faculties.Add(new SelectListItem { Text = faculty.FacultyName, Value = faculty.Id.ToString() });
            }
            return model;
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department
                {
                    DepartmentCode = model.DepartmentCode,
                    DepartmentName = model.DepartmentName,
                    FacultyId = model.FacultyId
                };
                entityRepository.Insert(department);
                entityRepository.Save();
                return Redirect("alldepartments");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateDepartmentData(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Department with Id { Id } could not be found";
                return View("NotFound");
            }
            else
            {
                Department department = entityRepository.GetById(Id);
                if (department == null)
                {
                    ViewBag.ErrorMessage = $"The Department with Id { Id } could not be found";
                    return View("NotFound");
                }
                UpdateDepartmentViewModel model = new UpdateDepartmentViewModel
                {
                    Id = department.Id,
                    DepartmentCode = department.DepartmentCode,
                    DepartmentName = department.DepartmentName,
                    FacultyId = department.FacultyId
                };
                GetAllFaculties(model);
                return PartialView(model);
            }
        }

        [HttpPost]
        public IActionResult UpdateDepartmentData(UpdateDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department department = entityRepository.GetById(model.Id);
                if (department == null)
                {
                    ViewBag.ErrorMessage = $"The Department with Id { model.Id } could not be found";
                    return View("NotFound");
                }
                department.DepartmentCode = model.DepartmentCode;
                department.DepartmentName = model.DepartmentName;
                department.FacultyId = model.FacultyId;
                entityRepository.Update(department);
                entityRepository.Save();
                return Json(new { success = true });
            }
            GetAllFaculties(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteDepartment(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Department with Id { Id } could not be found";
                return View("NotFound");
            }
            Department department = entityRepository.GetById(Id);
            if(department == null)
            {
                ViewBag.ErrorMessage = $"The Department with Reference Id = { Id } could not be found";
                return View("NotFound");
            }
            entityRepository.Delete(department.Id);
            entityRepository.Save();
            return Json(new { success = true });
        }

    }
}