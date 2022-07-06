using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public Enums.MessageType MessageType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
