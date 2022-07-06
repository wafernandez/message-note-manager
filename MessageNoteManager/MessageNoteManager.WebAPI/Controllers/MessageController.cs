using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.Domain;
using MessageNoteManager.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessageNoteManager.WebAPI.Controllers
{
    [Route("message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageLogic _messageLogic;
        private ILoginLogic _loginLogic;

        public MessageController(IMessageLogic messageLogic, ILoginLogic loginLogic)
        {
            _messageLogic = messageLogic;
            _loginLogic = loginLogic;
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult Create(CreateMessageDTO messageDTO)
        {
            try
            {
                string userAuthId = _loginLogic.GetLoggedUserId(User);
                Message result = _messageLogic.Create(messageDTO, userAuthId);

                return Created(string.Empty, result);
            }
            catch(UserNotFoundException unfEx)
            {
                return NotFound(unfEx.Message);
            }
            
        }

        [HttpPut("{id}/")]
        [Authorize(Policy = "User")]
        public IActionResult Update(int id, UpdateMessageDTO messageDTO)
        {
            try
            {
                string userAuthId = _loginLogic.GetLoggedUserId(User);
                Message result = _messageLogic.Update(id, messageDTO, userAuthId);

                return Ok(result);
            }
            catch (MessageNotFoundException mnfEx)
            {
                return NotFound(mnfEx.Message);
            }
            catch(UnauthorizedAccessException uaEx)
            {
                return Unauthorized(uaEx.Message);
            }
        }

        [HttpGet("list/")]
        [Authorize(Policy = "User")]
        public IActionResult GetOwn()
        {
            string userAuthId = _loginLogic.GetLoggedUserId(User);
            List<Message> result = _messageLogic.GetByUserId(userAuthId);

            return Ok(result);
        }

        [HttpGet("list-all/")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAll()
        {
            List<Message> result = _messageLogic.GetAll();

            return Ok(result);
        }
    }
}
