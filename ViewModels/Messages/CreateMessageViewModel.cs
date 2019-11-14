using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SchoolManagementSystem.ViewModels
{
    public class CreateMessagesViewModel
    {
        [Required]
        [EmailAddress]
        public string From { get; set; }
        [Required]
        [EmailAddress]
        public string To { get; set; }
        [Required]
        [StringLength(20)]
        public string Subject { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
    }
}