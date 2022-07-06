using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic.Interface
{
    public interface ILoginLogic
    {
        string GetLoggedUserId(ClaimsPrincipal User);
    }
}
