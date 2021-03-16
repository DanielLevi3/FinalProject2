using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    interface ILoginService
    {
        bool TryLogin(string userName, string password, out LoginToken<IUser> token, out FacadeBase facade);
    }
}