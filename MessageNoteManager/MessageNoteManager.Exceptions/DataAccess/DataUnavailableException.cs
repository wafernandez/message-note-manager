using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Exceptions
{
    public class DataUnavailableException : Exception
    {
        public DataUnavailableException() : base("Cannot access data source.")
        {
        }
    }
}
