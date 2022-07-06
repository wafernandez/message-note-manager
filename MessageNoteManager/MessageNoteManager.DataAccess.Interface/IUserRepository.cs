using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess.Interface
{
    public interface IUserRepository
    {
        User Add(User newUser);
        User GetByEmail(string userEmail);
        User GetByUserId(string userAuthId);
        List<User> GetAll();
    }
}
