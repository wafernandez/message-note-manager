using MessageNoteManager.DataAccess.Interface;
using MessageNoteManager.Domain;
using MessageNoteManager.Exceptions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _users = context.Set<User>();
            _context = context;
        }

        public User Add(User newUser)
        {
            _users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public List<User> GetAll()
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

        public User GetByEmail(string userEmail)
        {
            User user = _users.SingleOrDefault(u => u.Email == userEmail);
            return user;
        }

        public User GetByUserId(string userAuthId)
        {
            User user = _users.SingleOrDefault(u => u.UserId == userAuthId);
            return user;
        }

        private List<User> TryGetAll()
        {
            List<User> allUsers = _users.ToList();
            return allUsers;
        }
    }
}
