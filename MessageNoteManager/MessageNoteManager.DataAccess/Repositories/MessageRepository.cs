using MessageNoteManager.DataAccess.Interface;
using MessageNoteManager.Domain;
using MessageNoteManager.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DbSet<Message> _messages;
        private readonly DbContext _context;

        public MessageRepository(DbContext context)
        {
            _messages = context.Set<Message>();
            _context = context;
        }

        public Message Add(Message newMessage)
        {
            _messages.Add(newMessage);
            _context.SaveChanges();

            return newMessage;
        }

        public Message Update(Message toUpdate)
        {
            _messages.Update(toUpdate);
            _context.SaveChanges();

            return toUpdate;
        }

        public Message GetById(int messageId)
        {
            Message message = _messages
                                .Include(m => m.Sender)
                                .Include(m => m.Receiver)
                                .SingleOrDefault(m => m.Id == messageId);
            return message;
        }

        public List<Message> GetByUserId(string userId)
        {
            try
            {
                return TryGetByUserId(userId);
            }
            catch (SqlException)
            {
                throw new DataUnavailableException();
            }
            catch (DbException)
            {
                throw new DataUnavailableException();
            }
            catch (EntityException)
            {
                throw new DataUnavailableException();
            }
        }

        public List<Message> GetAll()
        {
            try
            {
                return TryGetAll();
            }
            catch (SqlException)
            {
                throw new DataUnavailableException();
            }
            catch (DbException)
            {
                throw new DataUnavailableException();
            }
            catch (EntityException)
            {
                throw new DataUnavailableException();
            }
        }

        private List<Message> TryGetAll()
        {
            List<Message> allMessages = _messages
                                        .Include(m => m.Sender)
                                        .Include(m => m.Receiver)
                                        .ToList();
            return allMessages;
        }

        private List<Message> TryGetByUserId(string userId)
        {
            List<Message> userMessages = _messages
                                        .Include(m => m.Sender)
                                        .Include(m => m.Receiver)
                                        .Where(m => m.Sender.UserId == userId)
                                        .ToList();
            return userMessages;
        }
    }
}
