using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models.Message
{
    public class ReceivedMessage
    {
        public long Id { get; set; }
        public bool IsRead { get; set; }

        //Foreign Keys
        public long MessageId { get; set; }
        public Message Message { get; set; }

        public string ReceiverId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}