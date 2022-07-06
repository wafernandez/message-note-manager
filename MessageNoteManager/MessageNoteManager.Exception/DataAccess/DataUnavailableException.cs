using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.Exception.DataAccess
{
    public class DataUnavailableException : Exception
    {
        public DataUnavailableException() : base("Can't access data source")
        {
        }
    }
}
