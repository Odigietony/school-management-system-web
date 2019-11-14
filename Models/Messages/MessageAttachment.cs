namespace SchoolManagementSystem.Models.Message
{
    public class MessageAttachment
    {
        public long Id { get; set; }
        public string Attachment { get; set; }

        //Foreign Kay
        public long MessageId { get; set; }
        public Message Message { get; set; }
    }
}