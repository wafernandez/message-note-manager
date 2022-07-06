using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class CreateMessageDTO
    {
        public Enums.MessageType MessageType { get; set; }
        public string Content { get; set; }
        public string ReceiverEmail{ get; set; }
    }
}
