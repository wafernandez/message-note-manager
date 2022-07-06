using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class NoteDTO
    {
        public Enums.NoteType NoteType { get; set; }
        public string Content { get; set; }
    }
}
