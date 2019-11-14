using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Models.Message
{
    public class Message
    {
        public long Id { get; set; }
        
        [StringLength(20)]
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string DateAndTime { get; set; }
        public bool IsDelivered { get; set; }

        //Foreign Keys
        public string AuthourId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}