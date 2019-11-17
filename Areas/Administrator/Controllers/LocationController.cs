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
            model.Locations = locationRepository.GetAll().Include(l => l.LocationCategory)
            .Include(l => l.Admin);
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
                    CategoryId = model.CategoryId,
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
                Title = location.Title, 
                Number = location.Number,
                CategoryId = location.CategoryId
            };
            GetAllCategories(model);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLocation(EditLocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location
                {
                    Title = model.Title,
                    AdminId = await GetCurrentLoggedInUserId(),
                    Number = model.Number,
                    CategoryId = model.CategoryId
                };
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
            locationRepository.Delete(location.Id);
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
            var location = locationRepository.GetById(Id);
            if (location == null)
            {
                ViewBag.ErrorMessage = $"location resource with { Id } not found";
                return View("Error");
            }
            EditCategoryViewModel model = new EditCategoryViewModel
            {
                Title = location.Title,
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult EditCategory(EditCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Location location = new Location
                {
                    Title = model.Title,
                };
                locationRepository.Update(location);
                locationRepository.Save();
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
        private IActionResult LocationInUse(string title)
        {
            Location location = locationRepository.GetByTitle(title);
            return location == null ? Json(true) : Json($"The location { title } is already registered");
        }

       
    }
}