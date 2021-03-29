using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject2
{
    public interface ILoginService
    {
        bool TryLogin(string userName, string password, out LoginToken<IUser> token, out FacadeBase facade);
    }
}