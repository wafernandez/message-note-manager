using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic.Interface
{
    public interface IUserLogic
    {
        User Create(CreateUserDTO userDTO);
        User GetByEmail(string userEmail);
        User GetByUserId(string userAuthId);
        List<User> GetAll();
    }
}
