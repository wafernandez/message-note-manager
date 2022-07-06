using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.DataAccess.Interface;
using MessageNoteManager.Domain;
using MessageNoteManager.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic
{
    public class MessageLogic : IMessageLogic
    {
        private IMessageRepository _messageRepository;
        private IUserLogic _userLogic;

        public MessageLogic(IMessageRepository messageRepository, IUserLogic userLogic)
        {
            _messageRepository = messageRepository;
            _userLogic = userLogic;
        }

        public Message Create(CreateMessageDTO messageDTO, string userAuthId)
        {
            User sender = _userLogic.GetByUserId(userAuthId);
            if (sender == null) throw new UserNotFoundException("Logged in user is not registered.");

            User receiver = _userLogic.GetByEmail(messageDTO.ReceiverEmail);
            if (receiver == null) throw new UserNotFoundException($"User with email {messageDTO.ReceiverEmail} does not exists.");

            Message newMessage = new Message()
            {
                MessageType = messageDTO.MessageType,
                Content = messageDTO.Content,
                Sender = sender,
                Receiver = receiver,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return _messageRepository.Add(newMessage);
        }

        public Message Update(int messageId, UpdateMessageDTO messageDTO, string userAuthId)
        {
            Message toUpdate = _messageRepository.GetById(messageId);
            if (toUpdate == null) throw new MessageNotFoundException();

            if (toUpdate.Sender.UserId != userAuthId) throw new UnauthorizedAccessException("You are not the message owner.");

            toUpdate.Content = messageDTO.Content;
            toUpdate.MessageType = messageDTO.MessageType;
            toUpdate.UpdatedAt = DateTime.Now;

            return _messageRepository.Update(toUpdate);
        }

        public List<Message> GetByUserId(string userAuthId)
        {
            return _messageRepository.GetByUserId(userAuthId);
        }

        public List<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }
    }
}
