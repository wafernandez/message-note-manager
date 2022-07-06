using MessageNoteManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess.Interface
{
    public interface INoteRepository
    {
        Note Add(Note newNote);
        Note Update(Note toUpdate);
        Note GetById(int noteId);
        List<Note> GetByUserId(string userId);
        List<Note> GetAll();
    }
}
