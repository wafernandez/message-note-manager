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
    public class NoteLogic : INoteLogic
    {
        private INoteRepository _noteRepository;
        private IUserLogic _userLogic;

        public NoteLogic(INoteRepository noteRepository, IUserLogic userLogic)
        {
            _noteRepository = noteRepository;
            _userLogic = userLogic;
        }

        public Note Create(NoteDTO noteDTO, string userAuthId)
        {
            User owner = _userLogic.GetByUserId(userAuthId);
            if (owner == null) throw new UserNotFoundException("Logged in user is not registered.");

            Note newNote = new Note()
            {
                Content = noteDTO.Content,
                NoteType = noteDTO.NoteType,
                Owner = owner,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return _noteRepository.Add(newNote);
        }

        public Note Update(int noteId, NoteDTO noteDTO, string userAuthId)
        {
            Note toUpdate = _noteRepository.GetById(noteId);
            if (toUpdate == null) throw new NoteNotFoundException();

            if (toUpdate.Owner.UserId != userAuthId) throw new UnauthorizedAccessException("You are not the note owner.");

            toUpdate.Content = noteDTO.Content;
            toUpdate.NoteType = noteDTO.NoteType;
            toUpdate.UpdatedAt = DateTime.Now;

            return _noteRepository.Update(toUpdate);
        }

        public List<Note> GetByUserId(string userAuthId)
        {
            return _noteRepository.GetByUserId(userAuthId);
        }

        public List<Note> GetAll()
        {
            return _noteRepository.GetAll();
        }
    }
}
