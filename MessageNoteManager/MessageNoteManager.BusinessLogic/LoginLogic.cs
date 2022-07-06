using MessageNoteManager.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.BusinessLogic
{
    public class LoginLogic : ILoginLogic
    {
        public string GetLoggedUserId(ClaimsPrincipal User)
        {
            var identityClaim = User.Claims.FirstOrDefault(c => c.Type.Contains("identity"));
            return identityClaim != null ? identityClaim.Value.Split('|')[1] : string.Empty;
        }
    }
}
