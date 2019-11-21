using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Areas.Administrator.ViewModels;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class AdminTaskController : Controller
    {
        private readonly IEntityRepository<AdminTask> taskRepository;
        private readonly ILocation locationRepository;
        public AdminTaskController(IEntityRepository<AdminTask> taskRepository, 
        ILocation locationRepository)
        {
            this.locationRepository = locationRepository;
            this.taskRepository = taskRepository;
        }

        public IActionResult AllTasks()
        {
            AllTasksViewModel model = new AllTasksViewModel();
            model.AdminTask = taskRepository.GetAll().Include(t => t.Location);
            GetLocations(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateNewTask()
        {
            CreateNewTaskViewModel model = new CreateNewTaskViewModel();
            GetLocations(model);
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewTask(CreateNewTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                AdminTask task = new AdminTask
                {
                    Date = model.Date,
                    Time = model.Time,
                    Title = model.Title,
                    Description = model.Description,
                    LocationId = model.LocationId
                };
                string task_title = model.Title;
                taskRepository.Insert(task);
                taskRepository.Save();
                ViewBag.Success = $"Task { task_title } was created successfully.";
                return RedirectToAction("alltasks",  ViewBag.Success );
            }
            GetLocations(model);
            return RedirectToAction("alltasks", model);
        }

        [HttpGet]
        public IActionResult EditTask(long Id)
        {
            var task = taskRepository.GetById(Id);
            if (task == null)
            {
                ViewBag.ErrorMessage = $"Task resource with { Id } not found";
                return View("Error");
            }
            EditTaskViewModel model = new EditTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Date = task.Date,
                Time = task.Time,
                Description = task.Description,
                LocationId = task.LocationId
            };
            GetLocations(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditTask(EditTaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                AdminTask task = taskRepository.GetById(model.Id);
                task.Title = model.Title;
                task.Time = model.Time;
                task.Date = model.Date;
                task.Description = model.Description;
                task.LocationId = model.LocationId; 
                taskRepository.Update(task);
                taskRepository.Save();
                return Json(new { success = true });
            }
            ViewBag.Success = "Task Updated Successfully.";
            GetLocations(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteTask(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The Task Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            AdminTask task = taskRepository.GetById(Id);
            if (task == null)
            {
                ViewBag.ErrorMessage = $"The task Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            string task_title = task.Title;
            taskRepository.Delete(task.Id);
            taskRepository.Save();
            ViewBag.Success = $"Task { task_title } was deleted successfully.";
            return Json(new { success = true });
        }

        public CreateNewTaskViewModel GetLocations(CreateNewTaskViewModel model)
        {
            var locations = locationRepository.GetAll();
            foreach(var location in locations)
            {
                model.Locations.Add(new SelectListItem { Text = location.Title, Value = location.Id.ToString()});
            }
            return model;
        }
    }
}