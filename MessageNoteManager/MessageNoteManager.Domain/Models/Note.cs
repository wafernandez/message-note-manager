using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public Enums.NoteType NoteType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Owner { get; set; }
    }
}
