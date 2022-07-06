using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Exceptions
{
    public class MessageNotFoundException : Exception
    {
        public MessageNotFoundException() : base("Message with specified ID not found.")
        {
        }
    }
}
