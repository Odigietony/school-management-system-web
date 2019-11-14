using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data.Repository;

namespace SchoolManagementSystem.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IMessageRepository messageRepository;
        public MessagesController(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public IActionResult Inbox()
        {
            var model = messageRepository.GetAllReceivedMessagesByUser();
            return View(model);
        }

        public IActionResult SentMessages()
        {
            var model = messageRepository.GetAllReceivedMessagesByUser();
            return View(model);
        }

        public IActionResult CreateMessage()
        {
            return View();
        }
    }
}