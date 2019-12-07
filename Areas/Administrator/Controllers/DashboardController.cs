using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Areas.Administrator.ViewModels;

namespace SchoolManagementSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IEntityRepository<Admin> entityRepository;
        private readonly IEventRepository eventRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ITaskRepository taskRepository;
        public DashboardController(IEntityRepository<Admin> entityRepository, ITaskRepository taskRepository, IEventRepository eventRepository,
        IMessageRepository messageRepository, 
        ITeacherRepository teacherRepository,
        IStudentRepository studentRepository)
        {
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
            this.entityRepository = entityRepository;
            this.messageRepository = messageRepository;
            this.taskRepository = taskRepository;
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        
        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel
            {
                AllActiveStudents = studentRepository.FindAllStudent().Count(),
                AllTeachers = teacherRepository.GetAllTeachers().Count(),
                AllMessages = messageRepository.GetAllReceivedMessagesByUser().Count(),
                TodaysTasks = taskRepository.GetTodaysTasks().ToList(),
                AllEvents = eventRepository.GetAll().Count(),
                TodaysEvents = eventRepository.GetTodaysEvents().Count(),
            };
            return View(model);
        }
    }
}