using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.ViewModels;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using System.Linq;

namespace SchoolManagementSystem.Controllers
{
    public class EventCategoryController : Controller
    {
        private readonly IEventRepository eventRepository;
        public EventCategoryController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

         //Event Categories
        [HttpGet]
        public IActionResult AllCategories() 
        {
            AllCategoriesViewModel model = new AllCategoriesViewModel();
            model.EventCategories = eventRepository.GetAllEventCategories().ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult NewCategory() => Redirect("allcategories");
        [HttpPost]
        public IActionResult NewCategory(NewCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                EventCategory category = new EventCategory
                {
                    Title = model.Title
                };
                eventRepository.InsertEventCategory(category);
                eventRepository.Save();
                return RedirectToAction("allcategories");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditCategory(long Id)
        {
            EventCategory category = eventRepository.GetEventCategoryById(Id);
            if(category == null)
            {
                ViewBag.ErrorMessage = $"Unknowm event category resource";
                return View("error");
            }
            EditEventViewModel model = new EditEventViewModel
            {
                Title = category.Title,
                Id = category.Id
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditCategory(EditEventViewModel model)
        {
            EventCategory category = eventRepository.GetEventCategoryById(model.Id);
            if(category != null && ModelState.IsValid)
            {
                category.Title = model.Title;
                eventRepository.UpdateEventCategory(category);
                eventRepository.Save();
                TempData["category-updated"] = $"The Category, { category.Title }, was updated successfully";
                return Json(new { success = true });
            }
            else
            {
                return PartialView(model);
            }
        }

        [HttpPost]
        public IActionResult DeleteCategory(long Id)
        {
            if(Id > 0)
            {
                EventCategory category = eventRepository.GetEventCategoryById(Id);
                if(category == null)
                {
                    ViewBag.ErrorMessage = $"Unknowm Category resource";
                    return View("error");
                }
                string category_title = category.Title;
                eventRepository.DeleteEventCategory(category);
                eventRepository.Save();
                TempData["category-deleted"] = $"The event category with title { category_title  }, was permanently deleted";
                return Json(new { success = true });
            }
            else
            {
                ViewBag.ErrorMessage = $"Unknowm Category resource";
                return View("error");
            }
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public IActionResult CategoryTitleInUse(string Title)
        {
            EventCategory category = eventRepository.GetEventCategoryByTitle(Title);
            return category == null ? Json(true) : Json($"The category { Title } is already registered");
        }
    }
}