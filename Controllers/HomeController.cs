using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

namespace SchoolManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }
        public ViewResult Contact()
        {
            return View();
        }
        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}