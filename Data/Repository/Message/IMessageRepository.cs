using System.Collections.Generic;
using SchoolManagementSystem.Models.Message;

namespace SchoolManagementSystem.Data.Repository
{
    public interface IMessageRepository
    {
        void SendMessage();
        void SendBulkMessage();
        ICollection<Message> GetAllSentMessagesByUser();
        ICollection<ReceivedMessage> GetAllReceivedMessagesByUser();
    }
}