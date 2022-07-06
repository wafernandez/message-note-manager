using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string exMessage) : base(exMessage)
        {
        }
    }
}