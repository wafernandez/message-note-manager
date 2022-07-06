using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Exceptions
{
    public class NoteNotFoundException : Exception
    {
        public NoteNotFoundException() : base("Note with specified ID not found.")
        {
        }
    }
}
