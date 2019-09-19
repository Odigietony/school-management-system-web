using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IEntityRepository<Faculty> entityRepository;
        public FacultyController(IEntityRepository<Faculty> entityRepository)
        {
            this.entityRepository = entityRepository; 
        }
    }
}