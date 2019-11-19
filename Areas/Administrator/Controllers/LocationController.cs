using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class LocationController : Controller
    {
        private readonly ILocation locationRepository;
        private readonly IEntityRepository<LocationCategory> categoryRepository;
        private readonly IEntityRepository<Admin> adminRepository;
        private readonly UserManager<IdentityUser> userManager;
        public LocationController(ILocation locationRepository, IEntityRepository<Admin> adminRepository,
        UserManager<IdentityUser> userManager,
        IEntityRepository<LocationCategory> categoryRepository)
        {
            this.userManager = userManager;
            this.categoryRepository = categoryRepository;
            this.locationRepository = locationRepository;
            this.adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult AllLocations()
        {
            AllLocationsViewModel model = new AllLocationsViewModel();
            model.Locations = locationRepository.GetAll().Include(l => l.Admin)
            .Include(l => l.LocationCategory);
            GetAllCategories(model); 
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewLocation()
        {
            AddNewLocationViewModel model = new AddNewLocationViewModel();
            GetAllCategories(model);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLocation(AddNewLocationViewModel model)
        {
            if (ModelState.IsValid)
            {  
                Location location = new Location
                {
                    Title = model.Title,
                    Number = model.Number,
                    LocationCategoryId = model.CategoryId,
                    AdminId = await GetCurrentLoggedInUserId()
                };
                locationRepository.Insert(location);
                locationRepository.Save();
                return Redirect("alllocations");
            }
            GetAllCategories(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditLocation(long Id)
        {
            var location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"location resource with { Id } not found";
                return View("Error");
            }
            EditLocationViewModel model = new EditLocationViewModel
            {
                Id = location.Id,
                Title = location.Title, 
                Number = location.Number,
                CategoryId = location.LocationCategoryId
            };
            GetAllCategories(model);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(EditLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Location location = locationRepository.GetById(model.Id); 
                location.Title = model.Title;
                location.AdminId = await GetCurrentLoggedInUserId();
                location.Number = model.Number;
                location.LocationCategoryId = model.CategoryId;
                locationRepository.Update(location);
                locationRepository.Save();
                return Json(new { success = true });
            }
            GetAllCategories(model);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Deletelocation(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            Location location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            locationRepository.Delete(location);
            locationRepository.Save();
            return Json(new { success = true });
        } 

        public IActionResult AllCategories()
        {
            AllCategories model = new AllCategories();
            model.Categories = categoryRepository.GetAll().OrderBy(c => c.Title);
            return View(model);
        }

        public IActionResult AddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory(AddNewCategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                LocationCategory category = new LocationCategory
                {
                    Title = model.Title
                };
                categoryRepository.Insert(category);
                categoryRepository.Save();
                return Redirect("allcategories");
            }
            return View(model);
        }

         [HttpGet]
        public IActionResult EditCategory(long Id)
        {
            var category = categoryRepository.GetById(Id);
            if (category == null)
            {
                ViewBag.ErrorMessage = $"category resource with { Id } not found";
                return View("Error");
            }
            EditCategoryViewModel model = new EditCategoryViewModel
            {
                Id = category.Id,
                Title = category.Title,
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                LocationCategory category = categoryRepository.GetById(model.Id);
                category.Title = model.Title;
                categoryRepository.Update(category);
                categoryRepository.Save();
                return Json(new { success = true });
            }
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult DeleteCategory(long Id)
        {
            if (Id.Equals(0))
            {
                ViewBag.ErrorMessage = $"The location Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            LocationCategory category = categoryRepository.GetById(Id);
            if (category == null)
            {
                ViewBag.ErrorMessage = $"The category Resource with Id = { Id } could not be found";
                return View("NotFound");
            }
            categoryRepository.Delete(category.Id);
            categoryRepository.Save();
            return Json(new { success = true });
        }

        private async Task<long> GetCurrentLoggedInUserId()
        {
            IdentityUser user = await GetUserId();
            Admin admin = adminRepository.GetByUserId(user.Id);
            return admin.Id;
        }

        private Task<IdentityUser> GetUserId() => userManager.GetUserAsync(HttpContext.User);
        private AddNewLocationViewModel GetAllCategories(AddNewLocationViewModel model)
        {
            var categories = categoryRepository.GetAll();
            foreach(var category in categories)
            {
                model.Categories.Add(new SelectListItem { Value = category.Id.ToString(), Text = category.Title });
            }
            return model;
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public IActionResult LocationInUse(string Title)
        {
            Location location = locationRepository.GetByTitle(Title);
            return location == null ? Json(true) : Json($"The location { Title } is already registered");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public IActionResult LocationCategoryInUse(string Title)
        {
            LocationCategory category = locationRepository.GetCategoryByTitle(Title);
            return category == null ? Json(true) : Json($"The category { Title } is already registered");
        }
    }
}