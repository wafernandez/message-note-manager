using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic.Interface
{
    public interface INoteLogic
    {
        Note Create(NoteDTO noteDto, string userAuthId);
        Note Update(int noteId, NoteDTO noteDTO, string userAuthId);
        List<Note> GetByUserId(string userAuthId);
        List<Note> GetAll();
    }
}
