
namespace FinalProject2
{
    //public class LoginToken<T> : ILoginToken where T : IUser


    public class LoginToken<T> : ILoginToken where T: IUser
    {
        public T User { get; set; } 
    }
}