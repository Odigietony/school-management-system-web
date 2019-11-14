using System.Collections.Generic;
using System.Linq;
using SchoolManagementSystem.Models.Message;

namespace SchoolManagementSystem.Data.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext context;
        public MessageRepository(AppDbContext context)
        {
            this.context = context; 
        }
        public ICollection<ReceivedMessage> GetAllReceivedMessagesByUser()
        {
            return context.ReceivedMessages.ToList();
        }

        public ICollection<Message> GetAllSentMessagesByUser()
        {
            return context.Messages.ToList();
        }

        public void SendBulkMessage()
        {
            throw new System.NotImplementedException();
        }

        public void SendMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}