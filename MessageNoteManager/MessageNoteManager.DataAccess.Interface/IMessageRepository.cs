using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess.Interface
{
    public interface IMessageRepository
    {
        Message Add(Message newMessage);
        Message Update(Message toUpdate);
        Message GetById(int messageId);
        List<Message> GetByUserId(string userId);
        List<Message> GetAll();
    }
}
