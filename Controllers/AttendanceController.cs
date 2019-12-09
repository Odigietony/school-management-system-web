using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IStudentRepository studentRepository;
        public AttendanceController(IAttendanceRepository attendanceRepository, IStudentRepository studentRepository,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.attendanceRepository = attendanceRepository;
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GeneralAttendanceReport()
        {
            var model = attendanceRepository.GetAllAttendance();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> StudentAttendance()
        {
            long studentId = 0;
            if (signInManager.IsSignedIn(User) && User.IsInRole("Student"))
            {
                IdentityUser user = await userManager.GetUserAsync(HttpContext.User);
                Student student = studentRepository.FindStudentByUserId(user.Id);
                studentId = student.Id;
            }
            var model = attendanceRepository.GetAllAttendanceByStudent(studentId);
            return View();
        }
    }
}