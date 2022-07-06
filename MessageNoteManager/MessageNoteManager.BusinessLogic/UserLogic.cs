using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.DataAccess.Interface;
using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(CreateUserDTO userDTO)
        {
            User newUser = new User()
            {
                UserId = userDTO.UserId,
                Email = userDTO.Email,
                UserType = userDTO.UserType,
                Name = userDTO.Name,
                CreatedAt = DateTime.Now
            };

            return _userRepository.Add(newUser);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetByEmail(string userEmail)
        {
            return _userRepository.GetByEmail(userEmail);
        }

        public User GetByUserId(string userAuthId)
        {
            return _userRepository.GetByUserId(userAuthId);
        }
    }
}
