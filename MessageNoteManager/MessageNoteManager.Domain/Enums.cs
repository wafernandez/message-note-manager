using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class Enums
    {
        public enum UserType
        {
            Administrator,
            NormalUser
        }

        public enum MessageType
        {
            High,
            Medium,
            Low
        }

        public enum NoteType
        {
            Hot,
            Medium,
            Low
        }
    }
}
