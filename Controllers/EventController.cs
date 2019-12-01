using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Helpers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.ViewModels;
using System;

namespace SchoolManagementSystem.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository eventRepository;
        private readonly IProcessFileUpload fileUpload;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILocation locationRepository;
        public EventController(IEventRepository eventRepository, ILocation locationRepository,
        IHostingEnvironment hostingEnvironment,
        IProcessFileUpload fileUpload)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.fileUpload = fileUpload;
            this.eventRepository = eventRepository;
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = eventRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult UpcomingEvents()
        {
            var model = eventRepository.GetAllUpcomingEvents();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult TodaysEvent() => View(eventRepository.GetTodaysEvents());

        [HttpGet]
        [Authorize]
        public IActionResult AddEvent()
        {
            AddEventViewModel model = new AddEventViewModel();
            GetAllEventCategories(model);
            GetAllLocations(model);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddEvent(AddEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                Event events = new Event
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    EventGuests = model.EventGuests,
                    Fee = model.Fee.ToString(),
                    Image = fileUpload.UploadImage(model.Image, "event_images"),
                    Sponsor = model.Sponsor,
                    Speaker = model.Speaker,
                    EventCategoryId = model.EventCategoryId,
                    LocationId = model.LocationId
                };
                eventRepository.InsertEvent(events);
                eventRepository.Save();
                TempData["event_created"] = $"Event { events.Title } was created successfully";
                return Redirect("index");
            }
            GetAllEventCategories(model);
            GetAllLocations(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEvent(long eventId)
        {
            Event events = eventRepository.GetEventById(eventId);
            if (events == null)
            {
                ViewBag.ErrorMessage = $"The event with reference id = { eventId } could not be found";
                return View("error");
            }
            
            EditEventViewModel model = new EditEventViewModel
            {
                Id = events.Id,
                Title = events.Title,
                Description = events.Description,
                Date = events.Date,
                StartTime = events.StartTime,
                EndTime = events.EndTime,
                EventGuests = events.EventGuests,
                Fee = Convert.ToDecimal(events.Fee),
                ExistingPhotoPath = events.Image,
                Sponsor = events.Sponsor,
                Speaker = events.Speaker,
                EventCategoryId = events.EventCategoryId,
                LocationId = events.LocationId
            };
            GetAllEventCategories(model);
            GetAllLocations(model);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditEvent(EditEventViewModel model)
        {
            Event events = eventRepository.GetEventById(model.Id);
            if (events == null)
            {
                ViewBag.ErrorMessage = $"The event with reference id = { model.Id } could not be found";
                return View("error");
            }
            if (ModelState.IsValid)
            {
                events.Title = model.Title;
                events.Description = model.Description;
                events.Date = model.Date;
                events.StartTime = model.StartTime;
                events.EndTime = model.EndTime;
                events.EventGuests = model.EventGuests;
                events.Fee = model.Fee.ToString();
                events.Speaker = model.Speaker;
                events.Sponsor = model.Sponsor;
                events.EventCategoryId = model.EventCategoryId;
                events.LocationId = model.LocationId;
                /*
                if a new image is inserted and there is an existing image path already,
                get the existing image path and delete it.
                replace it with the new image inserted
                */ 
                if (model.Image != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "event_images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    events.Image = fileUpload.UploadImage(model.Image, "event_images");
                }
                eventRepository.UpdateEvent(events);
                eventRepository.Save();
                TempData["event_updated"] = $"Event, { events.Title }, was updated successfully";
                return Redirect("index");
            }
            GetAllEventCategories(model);
            GetAllLocations(model);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult EventDetails(long Id)
        {
            Event events = eventRepository.GetEventById(Id);
            if(events == null)
            {
                ViewBag.ErrorMessage = $"The event with reference Id = { Id } could not be found";
                return View("error");
            }
            EventDetailsViewModel model = new EventDetailsViewModel
            {
                GetEvent = events,
                EventLocation = locationRepository.GetById(events.LocationId),
                EventCat = eventRepository.GetEventCategoryById(events.EventCategoryId)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteEvent(long Id)
        {
            Event events = eventRepository.GetEventById(Id);
            string event_title = events.Title;
            if(events == null)
            {
                ViewBag.ErrorMessage = $"Invalid event request made";
                return View("error");
            }
            if(events.Image != null)
            {
                string filePath = Path.Combine(hostingEnvironment.WebRootPath, "event_images", events.Image);
                System.IO.File.Delete(filePath);
            }
            eventRepository.DeleteEvent(events);
            eventRepository.Save();
            TempData["event_deleted"] = $"Event { event_title } was permanently deleted";
            return View("index");
        }

        private AddEventViewModel GetAllEventCategories(AddEventViewModel model)
        {
            var eventCategories = eventRepository.GetAllEventCategories();
            foreach (var categories in eventCategories)
            {
                model.EventCategories.Add(new SelectListItem { Text = categories.Title, Value = categories.Id.ToString() });
            }
            return model;
        }

         private AddEventViewModel GetAllLocations(AddEventViewModel model)
        {
            var locations = locationRepository.GetAll();
            foreach (var location in locations)
            {
                model.Locations.Add(new SelectListItem { Text = location.Title, Value = location    .Id.ToString() });
            }
            return model;
        }
    }
}