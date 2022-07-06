using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic.Interface
{
    public interface IMessageLogic
    {
        Message Create(CreateMessageDTO messageDTO, string userAuthId);
        Message Update(int messageId, UpdateMessageDTO messageDTO, string userAuthId);
        List<Message> GetByUserId(string userAuthId);
        List<Message> GetAll();
    }
}
