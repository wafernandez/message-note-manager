using Microsoft.AspNetCore.Mvc;
using MessageNoteManager.Domain;
using MessageNoteManager.BusinessLogic.Interface;
using MessageNoteManager.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace MessageNoteManager.WebAPI.Controllers
{
    [Route("note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteLogic _noteLogic;
        private ILoginLogic _loginLogic;

        public NoteController(INoteLogic noteLogic, ILoginLogic loginLogic)
        {
            _noteLogic = noteLogic;
            _loginLogic = loginLogic;
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult Create(NoteDTO noteDTO)
        {
            try
            {
                string userAuthId = _loginLogic.GetLoggedUserId(User);
                Note result = _noteLogic.Create(noteDTO, userAuthId);

                return Created(string.Empty, result);
            }
            catch (UserNotFoundException unfEx)
            {
                return NotFound(unfEx.Message);
            }
        }

        [HttpPut("{id}/")]
        [Authorize(Policy = "User")]
        public IActionResult Update(int id, NoteDTO noteDTO)
        {
            try
            {
                string userAuthId = _loginLogic.GetLoggedUserId(User);
                Note result = _noteLogic.Update(id, noteDTO, userAuthId);

                return Ok(result);
            }
            catch (NoteNotFoundException nnfEx)
            {
                return NotFound(nnfEx.Message);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                return Unauthorized(uaEx.Message);
            }
        }

        [HttpGet("list/")]
        [Authorize(Policy = "User")]
        public IActionResult GetOwn()
        {
            string userAuthId = _loginLogic.GetLoggedUserId(User);
            List<Note> result = _noteLogic.GetByUserId(userAuthId);

            return Ok(result);
        }

        [HttpGet("list-all/")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAll()
        {
            List<Note> result = _noteLogic.GetAll();

            return Ok(result);
        }
    }
}
