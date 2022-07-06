using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageNoteManager.WebAPI.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost]
        [Authorize(Policy = "SuperAdmin")]
        public IActionResult Create(CreateUserDTO userDTO)
        {
            User result = _userLogic.Create(userDTO);

            return Created(string.Empty, result);
        }

        [HttpGet("list-all/")]
        [Authorize(Policy = "SuperAdmin")]
        public IActionResult GetAll()
        {
            List<User> result = _userLogic.GetAll();

            return Ok(result);
        }
    }
}
